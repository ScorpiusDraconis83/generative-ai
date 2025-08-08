namespace Mscc.GenerativeAI
{
    /// <summary>
    /// Configures the input to the batch request.
    /// </summary>
    public class InputEmbedContentConfig
    {
        /// <summary>
        /// The requests to be processed in the batch.
        /// </summary>
        public InlinedEmbedContentRequests Requests { get; set; }
        /// <summary>
        /// The name of the `File` containing the input requests.
        /// </summary>
        public string FileName { get; set; }
    }
}