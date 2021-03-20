using Microsoft.Extensions.Configuration;

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
        }
    }
}
