using System;
using Microsoft.EntityFrameworkCore;

namespace Restrike.GitHubIntegration.EFDAL
{
    partial class GitHubIntegrationEntities
    {

        public GitHubIntegrationEntities(IContextStartup startup, DbContextOptions options)
          : base(options)
        {
            if (startup == null)
                throw new Exceptions.ContextConfigurationException("Startup cannot be null");

            _contextStartup = startup;
            _tenantId = (this.ContextStartup as TenantContextStartup)?.TenantId;
            InstanceKey = Guid.NewGuid();
            if (_contextStartup.CommandTimeout > 0)
                this.CommandTimeout = _contextStartup.CommandTimeout;
            this.OnContextCreated();
        }

        public DbContextOptions DbOptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            this.DbOptions = optionsBuilder.Options;
        }

        public virtual Guid? TenantId
        {
            get
            {
                var tenantId = (this.ContextStartup as TenantContextStartup).TenantId;
                if (Guid.TryParse(tenantId, out Guid g))
                    return g;
                return null;
            }
        }
    }

}
