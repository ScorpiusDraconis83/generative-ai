using Google.Apis.Util.Store;
using Mscc.GenerativeAI.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using gauth = Google.Apis.Auth.OAuth2;

namespace Mscc.GenerativeAI.Google
{
    /// <summary>
    /// Helper class leveraging Google API Client Libraries.
    /// OAuth 2.0 credential for accessing protected resources using an access token, as well as optionally refreshing 
    /// the access token when it expires using a refresh token.
    /// </summary>
    // Reference: https://cloud.google.com/docs/authentication 
    public class GenerativeModelGoogle
    {
        private static readonly IReadOnlyList<string> s_scopes =
        [
            "https://www.googleapis.com/auth/cloud-platform",
            "https://www.googleapis.com/auth/generative-language.retriever",
            "https://www.googleapis.com/auth/generative-language.tuning"
        ];

        private const string DefaultClientFile = "client_secret.json";
        private const string DefaultTokenFile = "token.json";
        private const string DefaultCertificateFile = "key.p12";

        private readonly gauth.ICredential _credential;

        /// <summary>
        /// Gets or sets the project ID for the service.
        /// </summary>
        public string ProjectId { get; set; }
        /// <summary>
        /// Gets or sets the region for the service.
        /// </summary>
        public string Region { get; set; }
        private List<SafetySetting> SafetySettings { get; set; }
        private GenerationConfig GenerationConfig { get; set; }
        private Tools Tools { get; set; }

        /// <summary>
        /// Private constructor used by async factory methods. Stores the pre-resolved credential.
        /// </summary>
        private GenerativeModelGoogle(gauth.ICredential credential)
        {
            _credential = credential;
        }

        /// <summary>
        /// Private constructor for service account credentials — fully synchronous, no async work required.
        /// </summary>
        private GenerativeModelGoogle(string serviceAccountEmail, string? certificate, string? passphrase)
        {
            var x509Certificate = new X509Certificate2(
                certificate ?? DefaultCertificateFile,
                passphrase,
                X509KeyStorageFlags.Exportable);
            _credential = new gauth.ServiceAccountCredential(
                new gauth.ServiceAccountCredential.Initializer(serviceAccountEmail) { Scopes = s_scopes }
                    .FromCertificate(x509Certificate));
        }

        /// <summary>
        /// Creates an instance using application default credentials (ADC) or user credentials
        /// from a local <c>client_secret.json</c> file.
        /// </summary>
        /// <param name="cancellationToken">Optional. Cancellation token.</param>
        /// <returns>A fully initialised <see cref="GenerativeModelGoogle"/> instance.</returns>
        public static async Task<GenerativeModelGoogle> CreateAsync(CancellationToken cancellationToken = default)
        {
            var clientSecrets = await GetClientSecretsAsync(DefaultClientFile).ConfigureAwait(false);
            gauth.ICredential credential = clientSecrets == null
                ? await GetApplicationDefaultCredentialsAsync().ConfigureAwait(false)
                : await gauth.GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    s_scopes,
                    "user",
                    cancellationToken,
                    new FileDataStore(DefaultTokenFile)).ConfigureAwait(false);
            return new GenerativeModelGoogle(credential);
        }

        /// <summary>
        /// Creates an instance using a service account certificate.
        /// </summary>
        /// <param name="serviceAccountEmail">Service account email address.</param>
        /// <param name="certificate">Optional. Path to the .p12 certificate file.</param>
        /// <param name="passphrase">Optional. Certificate passphrase.</param>
        /// <returns>A fully initialised <see cref="GenerativeModelGoogle"/> instance.</returns>
        public static GenerativeModelGoogle CreateInstance(string serviceAccountEmail,
            string? certificate = null,
            string? passphrase = null)
            => new GenerativeModelGoogle(serviceAccountEmail, certificate, passphrase);

        /// <summary>
        /// Returns an instance of the specified model.
        /// </summary>
        /// <param name="model">The model name, ie. "gemini-pro"</param>
        /// <param name="requestOptions">Optional. Options for the request.</param>
        /// <param name="cancellationToken">Optional. Cancellation token.</param>
        /// <returns>The model.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<GenerativeModel> CreateModelAsync(string model = Model.Gemini25Pro,
            RequestOptions? requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            if (ProjectId == null) throw new ArgumentNullException(nameof(ProjectId));
            if (Region == null) throw new ArgumentNullException(nameof(Region));

            var accessToken = await _credential.GetAccessTokenForRequestAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            var vertex = new VertexAI(projectId: ProjectId, region: Region, accessToken: accessToken, requestOptions: requestOptions);
            return vertex.GenerativeModel(model, GenerationConfig, SafetySettings);
        }

        private static async Task<gauth.ClientSecrets?> GetClientSecretsAsync(string clientFile)
        {
            if (!File.Exists(clientFile))
                return null;

            using var stream = new FileStream(clientFile, FileMode.Open, FileAccess.Read,
                FileShare.Read, bufferSize: 4096, useAsync: true);
            return (await gauth.GoogleClientSecrets.FromStreamAsync(stream).ConfigureAwait(false)).Secrets;
        }

        private static async Task<gauth.GoogleCredential> GetApplicationDefaultCredentialsAsync()
        {
            try
            {
                var credential = await gauth.GoogleCredential.GetApplicationDefaultAsync().ConfigureAwait(false);

                if (credential.IsCreateScopedRequired)
                    foreach (var scope in s_scopes)
                        credential = credential.CreateScoped(scope);

                return credential;
            }
            catch (Exception e)
            {
                throw new ArgumentException(
                    "Failed to get application default credentials. Please ensure credentials are set up correctly (e.g., via gcloud auth application-default login) or provide them explicitly.",
                    e);
            }
        }
    }
}