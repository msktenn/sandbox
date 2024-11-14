using System.Linq;
using System.Security.Claims;

namespace Restrike.GitHubIntegration.Api
{
    internal static class ClaimsPrincipalExtensions
    {
        public const string TenantClaimName = "tenant-id";

        public static string GetTenantId(this ClaimsPrincipal principal)
            => principal?.FindAny(TenantClaimName)?.Value;

        public static string GetUserId(this ClaimsPrincipal principal)
            => principal?.FindAny(ClaimTypes.UserData)?.Value;

        private static Claim FindAny(this ClaimsPrincipal principal, params string[] type)
            => principal?.FindFirst(x => type.Any(y => string.Equals(x.Type, y)));
    }
}
