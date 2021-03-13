using System;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    [Serializable]
    public class GenericException : Exception
    {
        public GenericException(string message) : base(message)
        {
        }
    }
}
