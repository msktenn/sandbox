using System;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    /// <summary>
    /// Exception thrown when attempting to delete a data record results in a foreign key violation.
    /// </summary>
    [Serializable]
    public class EntityInUseException : Exception
    {
        private const string DefaultMessage = "The item is in use and cannot be deleted.";

        public EntityInUseException() : base(DefaultMessage) { }

        public EntityInUseException(Exception innerException) : base(DefaultMessage, innerException) { }
    }
}
