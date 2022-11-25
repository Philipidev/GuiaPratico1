using Swashbuckle.AspNetCore.SwaggerUI;

namespace GuiaPraticoRedes.Options.Swagger
{
    public class CustomSwaggerUIOptions
    {
        public static Action<SwaggerUIOptions> SetupAction =>
        CustomSwaggerOptionsSetupAction;

        private static void CustomSwaggerOptionsSetupAction(SwaggerUIOptions swaggerUIOptions)
        {
            swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "GuiaPratico");
            swaggerUIOptions.RoutePrefix = string.Empty;
#if DEBUG
            swaggerUIOptions.EnablePersistAuthorization();
#endif
            swaggerUIOptions.DisplayRequestDuration();
            swaggerUIOptions.EnableFilter();
            swaggerUIOptions.EnableDeepLinking();
            swaggerUIOptions.DefaultModelsExpandDepth(-1);
        }
    }
}
