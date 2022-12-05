using System.Security.Claims;

namespace WebProject.Infrastructure
{
    public static class ClaimsPrincipleExtensions
    {
        public static string Id(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
