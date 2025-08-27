#if NET472_OR_GREATER || NETSTANDARD2_0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
#endif

namespace Mscc.GenerativeAI
{
    /// <summary>
    /// A list of `Tool`s that can be used by the model to improve its abilities.
    /// </summary>
    public sealed class Tools : List<Tool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tools"/> class.
        /// </summary>
        public Tools() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tools"/> class with a list of delegates as functions.
        /// </summary>
        /// <param name="delegates">The delegates to be added as functions.</param>
        /// <exception cref="ArgumentNullException">Thrown when the delegates parameter is null.</exception>
        public Tools(Delegate[] delegates)
        {
            if (delegates == null) throw new ArgumentNullException(nameof(delegates));

            var functions = GetFunctions();
            foreach (Delegate function in delegates)
            {
                functions.Add(new(function));
            }
        }

        /// <summary>
        /// Adds the Google Search tool to the list of tools.
        /// </summary>
        public void AddGoogleSearch()
        {
            if (!this.Any(t => t.GoogleSearch is not null))
            {
                this.Add(new Tool() { GoogleSearch = new() });
            }
        }

        /// <summary>
        /// Adds the Google Search Retrieval tool to the list of tools.
        /// </summary>
        public void AddGoogleSearchRetrieval()
        {
            if (!this.Any(t => t.GoogleSearchRetrieval is not null))
            {
                this.Add(new Tool() { GoogleSearchRetrieval = new() });
            }
        }

        /// <summary>
        /// Adds the Code Execution tool to the list of tools.
        /// </summary>
        public void AddCodeExecution()
        {
            if (!this.Any(t => t.CodeExecution is not null))
            {
                this.Add(new Tool() { CodeExecution = new() });
            }
        }

        /// <summary>
        /// Adds the URL Context tool to the list of tools.
        /// </summary>
        public void AddUrlContext()
        {
            if (!this.Any(t => t.UrlContext is not null))
            {
                this.Add(new Tool() { UrlContext = new() });
            }
        }

        /// <summary>
        /// Adds the Google Maps tool to the list of tools.
        /// </summary>
        /// <param name="apiKey">The API key for Google Maps.</param>
        public void AddGoogleMaps(string? apiKey = null)
        {
            if (!this.Any(t => t.GoogleMaps is not null))
            {
                this.Add(new Tool()
                {
                    GoogleMaps = new()
                    {
                        AuthConfig = new()
                        {
                            ApiKeyConfig = new()
                            {
                                ApiKeyString = apiKey ??
                                               Environment.GetEnvironmentVariable("GOOGLE_MAPS_API_KEY")
                            }
                        }
                    }
                });
            }
        }

        /// <summary>
        /// Adds a function to the list of function declarations.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <param name="description">The description of the function.</param>
        public void AddFunction(string name, string? description)
        {
            GetFunctions().Add(new(name, description));
        }

        /// <summary>
        /// Adds a function to the list of function declarations.
        /// </summary>
        /// <param name="callback">The delegate to be added as a function.</param>
        public void AddFunction(Delegate callback)
        {
            GetFunctions().Add(new(callback));
        }

        /// <summary>
        /// Adds a function to the list of function declarations.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <param name="callback">The delegate to be added as a function.</param>
        public void AddFunction(string name, Delegate callback)
        {
            GetFunctions().Add(new(name, callback));
        }

        /// <summary>
        /// Adds a function to the list of function declarations.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <param name="description">The description of the function.</param>
        /// <param name="callback">The delegate to be added as a function.</param>
        public void AddFunction(string name, string? description, Delegate callback)
        {
            GetFunctions().Add(new(name, description, callback));
        }

        /// <summary>
        /// Removes a function from the list of function declarations by name.
        /// </summary>
        /// <param name="name">The name of the function to remove.</param>
        /// <returns>True if the function was removed, false otherwise.</returns>
        public bool RemoveFunction(string name)
        {
            var functions = this
                .Where(t => t.FunctionDeclarations is not null)
                .Select(t => t);
            foreach (var item in functions)
            {
                var function = item.FunctionDeclarations!.FirstOrDefault(f => f.Name == name);
                if (function is not null)
                {
                    return item.FunctionDeclarations.Remove(function);
                }
            }

            return false;
        }

        /// <summary>
        /// Removes a function from the list of function declarations by delegate.
        /// </summary>
        /// <param name="callback">The delegate of the function to remove.</param>
        /// <returns>True if the function was removed, false otherwise.</returns>
        public bool RemoveFunction(Delegate callback)
        {
            var functions = this
                .Where(t => t.FunctionDeclarations is not null)
                .Select(t => t);
            foreach (var item in functions)
            {
                var function = item.FunctionDeclarations!.FirstOrDefault(f => f.Callback == callback);
                if (function is not null)
                {
                    return item.FunctionDeclarations.Remove(function);
                }
            }

            return false;
        }

        /// <summary>
        /// Clears all functions from the list of function declarations.
        /// </summary>
        public void ClearFunctions()
        {
            var functions = this
                .Where(t => t.FunctionDeclarations is not null)
                .Select(t => t);
            foreach (var item in functions)
            {
                item.FunctionDeclarations!.Clear();
            }
        }

        /// <summary>
        /// Get list of available function declarations
        /// </summary>
        private List<FunctionDeclaration> GetFunctions()
        {
            Tool functions = new() { FunctionDeclarations = new() };
            if (this.Any(t => t.FunctionDeclarations is not null))
            {
                functions = this.FirstOrDefault(t => t.FunctionDeclarations is not null);
            }
            else if (Count == 0)
            {
                Add(functions);
            }
            else
            {
                Add(functions);
            }

            return functions!.FunctionDeclarations!;
        }

        internal Func<string, string, CancellationToken, ValueTask<object?>> DefaultFunctionCallback { get; set; } =
            (_, _, _) => throw new NotImplementedException("Function callback has not been implemented.");
    }
}