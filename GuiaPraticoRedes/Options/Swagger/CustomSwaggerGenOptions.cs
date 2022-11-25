using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace GuiaPraticoRedes.Options.Swagger
{
    public class CustomSwaggerGenOptions
    {
        public static Action<SwaggerGenOptions> SetupAction =>
       CustomSwaggerOptionsSetupAction;

        private static void CustomSwaggerOptionsSetupAction(SwaggerGenOptions swaggerGenOptions)
        {
            swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "GuiaPratico API", Version = "v1" });
            //string xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //string xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
            //swaggerGenOptions.IncludeXmlComments(xmlFilePath);
            swaggerGenOptions.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}_{apiDesc.RelativePath}");
            swaggerGenOptions.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    Description = $"JWT Authorization header using the {JwtBearerDefaults.AuthenticationScheme} scheme.",
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                });
            swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = JwtBearerDefaults.AuthenticationScheme,
                                Type = ReferenceType.SecurityScheme,
                            }
                        },new List<string>()
                    }
                });
        }
    }
}
