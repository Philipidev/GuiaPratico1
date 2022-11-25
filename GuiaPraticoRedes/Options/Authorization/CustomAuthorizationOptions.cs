using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace GuiaPraticoRedes.Options.Authorization
{
    public static class CustomAuthorizationOptions
    {
        public static Action<AuthorizationOptions> SetupAction =>
          CustomAuthorizationOptionsSetupAction;

        private static void CustomAuthorizationOptionsSetupAction(AuthorizationOptions authorizationOptions)
        {
            authorizationOptions.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.NameIdentifier)
                .Build();
        }
    }
}
