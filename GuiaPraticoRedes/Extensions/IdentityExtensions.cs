using System.Security.Claims;
using System.Security.Principal;

namespace GuiaPraticoRedes.Extensions
{
    public static class IdentityExtensions
    {
        public static Guid ObterIdUsuario(this IIdentity identity)
        {
            IEnumerable<Claim> claims = ((ClaimsIdentity)identity).Claims;
            if (claims is null || !claims.Any())
                claims = ((ClaimsIdentity)identity).Claims;

            return Guid.Parse(claims.First(c => c.Type.Equals(ClaimTypes.NameIdentifier)).Value);
        }

        public static Guid ObterIdUsuario(this ClaimsPrincipal user)
        {
            IEnumerable<Claim> claims = ((ClaimsIdentity)user.Identity).Claims;
            if (claims is null || !claims.Any())
                claims = user.Identities.SelectMany(a => a.Claims);

            return Guid.Parse(claims.First(c => c.Type.Equals(ClaimTypes.NameIdentifier)).Value);
        }
    }
}