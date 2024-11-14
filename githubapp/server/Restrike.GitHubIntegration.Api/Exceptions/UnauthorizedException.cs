using System;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {
        }
    }
}
