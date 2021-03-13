using Restrike.GitHubIntegration.EFDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Restrike.GitHubIntegration.Api
{
    public class DatabaseHelper
    {
        //Fake tenant to use when no actual tenant is necessary
        public const string NullTenant = "_NullTenant";

        public DatabaseHelper()
        {
            _dbOptions = GetDbOptions();
        }

        public DatabaseHelper(Microsoft.EntityFrameworkCore.DbContextOptions dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public static string ConnectionString { get; private set; }

        //Cache tenant information and connection strings
        private static Microsoft.EntityFrameworkCore.DbContextOptions _dbOptions = null;

        public static Microsoft.EntityFrameworkCore.DbContextOptions SetupPostgres(string connectionString)
        {
            ConnectionString = connectionString;
            _dbOptions = new DbContextOptionsBuilder<GitHubIntegrationEntities>()
                 .UseLazyLoadingProxies()
                // .UseNpgsql(connectionString)
                 .UseInMemoryDatabase(connectionString)
                 .Options;
            return _dbOptions;
        }

        public static Microsoft.EntityFrameworkCore.DbContextOptions SetupSqlServer(string connectionString)
        {
            ConnectionString = connectionString;
            _dbOptions = new DbContextOptionsBuilder<GitHubIntegrationEntities>()
                 .UseLazyLoadingProxies()
                //  .UseSqlServer(connectionString, builder =>
                //  {
                //      builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                //  })
                 .UseInMemoryDatabase(connectionString)
                 .Options;
            return _dbOptions;
        }

        public static Microsoft.EntityFrameworkCore.DbContextOptions SetupInMemory(string connectionString)
        {
            ConnectionString = connectionString;
            _dbOptions = new DbContextOptionsBuilder<GitHubIntegrationEntities>()
                 .UseLazyLoadingProxies()
                 .UseInMemoryDatabase(connectionString)
                 .EnableSensitiveDataLogging()
                 .Options;
            return _dbOptions;
        }

        public static Microsoft.EntityFrameworkCore.DbContextOptions GetDbOptions() => _dbOptions;

        public static TenantContextStartup GetStartupNoTenant()
        {
            return new TenantContextStartup(string.Empty, NullTenant);
        }

        public static TenantContextStartup GetStartup(Guid tenantId, string modifier, int commandTimeout = 0)
        {
            return new TenantContextStartup(modifier, tenantId.ToString(), true, commandTimeout);
        }

        public static GitHubIntegrationEntities GetContext(Guid tenantId, Microsoft.EntityFrameworkCore.DbContextOptions options = null)
        {
            return new GitHubIntegrationEntities(DatabaseHelper.GetStartup(tenantId, string.Empty), options ?? DatabaseHelper.GetDbOptions());
        }

        public static GitHubIntegrationEntities GetContext(Guid tenantId, string modifier, Microsoft.EntityFrameworkCore.DbContextOptions options = null)
        {
            return new GitHubIntegrationEntities(DatabaseHelper.GetStartup(tenantId, modifier), options ?? DatabaseHelper.GetDbOptions());
        }

        public static GitHubIntegrationEntities GetContextWithNoTenantId(Microsoft.EntityFrameworkCore.DbContextOptions options = null)
        {
            return new GitHubIntegrationEntities(GetStartupNoTenant(), options ?? DatabaseHelper.GetDbOptions());
        }

        public static List<Guid> GetTenants()
        {
            using (var context = DatabaseHelper.GetContextWithNoTenantId())
            {
                // return context.TenantMaster.Select(x => x.TenantId).ToList();
                return null;
            }
        }
    }
}
