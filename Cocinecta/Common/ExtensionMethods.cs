using System.Security.Claims;

namespace Cocinecta.Common
{
    public static class ExtensionMethods
    {
        public static string? GetUserId(this ClaimsPrincipal user) =>
            user == null || (user.Identity != null && !user.Identity.IsAuthenticated) ? null : (user.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public static string? GetExpirationToken(this ClaimsPrincipal user) =>
            user == null || (user.Identity != null && !user.Identity.IsAuthenticated) ? null : (user.Identities.FirstOrDefault()?.Claims.Where(x => x.Type == "exp").FirstOrDefault()?.Value);
    }
}
