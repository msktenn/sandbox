using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Restrike.GitHubIntegration.Api.Domain
{
    public interface IAwsCognitoDomain
    {
        Task CreateUserPool();
    }

    [ScopedLifetime]
    public class AwsCognitoDomain : IAwsCognitoDomain
    {
        public async Task CreateUserPool()
        {
            Log.Debug("Called: Task CreateUserPool()");
            var client = new AmazonCognitoIdentityProviderClient();
            var foo = new CreateUserPoolRequest();
            foo.

            var result = await Task.Run(() => { return new List<string>() { "a", "b", "c" }.ToArray<string>(); });

        }

    }
}
