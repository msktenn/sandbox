using System;
using Microsoft.Extensions.Configuration;
using Restrike.GitHubIntegration.Api;

namespace Restrike.GitHubIntegration.Tests
{
    public class BaseTest
    {
        public string Token { get; private set; }
        public string BaseUrl { get; private set; }

        public BaseTest()
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.development.json", optional: true, reloadOnChange: true)
            .Build();

            this.Token = configuration["Token"];
            this.BaseUrl = configuration["BaseUrl"];

            #region Configure Database
            var connectionString = configuration["ConnectionString"];
            if (configuration["DataServer"]?.ToLower() == "postgres")
                DatabaseHelper.SetupPostgres(connectionString);
            else if (configuration["DataServer"]?.ToLower() == "sql")
                DatabaseHelper.SetupSqlServer(connectionString);
            else
                throw new Exception("Invalid configuration");
            #endregion
        }
    }
}
