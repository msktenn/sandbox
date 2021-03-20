using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Restrike.GitHubIntegration.Api;

namespace Restrike.GitHubIntegration.Api.Domain
{
    public interface IWebhookDomain
    {
        Task<string[]> GetRepositories();
    }
    [ScopedLifetime]
    public class WebhookDomain : IWebhookDomain
    {
        public async Task<string[]> GetRepositories()
        {
            var result = await Task.Run(() => { return new List<string>() { "a", "b", "c" }.ToArray<string>(); });
            return result;
        }

    }
}
