using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GuiaPraticoRedes.Options.JwtBearer
{
    public static class CustomJwtBearerOptions
    {
        public static void CustomJwtBearerSetupAction(JwtBearerOptions jwtBearerOptions, IConfiguration Configuration)
        {
            var key = Encoding.ASCII.GetBytes(Config.Secret);
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            jwtBearerOptions.SaveToken = true;
            jwtBearerOptions.Events = new JwtBearerEvents()
            {
                OnTokenValidated = context =>
                {
                    context.HttpContext.User = context.Principal;
                    return Task.CompletedTask;
                },
                OnAuthenticationFailed = context =>
                {
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    return Task.CompletedTask;
                },
            };
        }
    }
}
