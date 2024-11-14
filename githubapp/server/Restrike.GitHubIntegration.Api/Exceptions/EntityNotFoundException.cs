using System;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    /// <summary>
    /// Used to indicate that an entity lookup failed.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() { }
    }
}
