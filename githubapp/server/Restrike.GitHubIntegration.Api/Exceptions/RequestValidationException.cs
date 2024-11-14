using System;
using System.Collections.Generic;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    /// <summary>
    /// Used to provide a general message explaining why a request cannot be processed.
    /// </summary>
    [Serializable]
    public class RequestValidationException : Exception
    {
        public Dictionary<string, IEnumerable<FieldErrorModel>> Errors { get; private set; }

        public RequestValidationException(Dictionary<string, IEnumerable<FieldErrorModel>> errors)
        {
            Errors = errors;
        }
    }
}
