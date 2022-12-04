using Serilog;
using Serilog.Events;

namespace GuiaPraticoRedes.Extensions
{
    public static class SerilogExtension
    {
        public static void AddSerilogApi(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var time = DateTime.Now.ToUniversalTime().Subtract(
                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                    ).TotalMilliseconds;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .Enrich.WithCorrelationId()
                .Enrich.WithProperty("GuiaPratico", $"API Serilog - {environment.EnvironmentName}")
                .Filter.ByExcluding(ExcluirRotas)
                .WriteTo.Async(wt => wt.File(
                    path: $"./logs/{time}.log",
                    outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}",
                    flushToDiskInterval: TimeSpan.FromSeconds(10),
                    fileSizeLimitBytes: 1000000 //1MB
                    )
                )
                .CreateLogger();
        }

        private static readonly string[] pathsToIgnore = new string[]
         {
                "\"/index",
                "\"/swagger",
                "\"/favicon",
                "\"/index",
                "\"/_framework",
                "\"/_vs",
         };

        private static Func<LogEvent, bool> ExcluirRotas => log =>
        {
            string path = log.Properties.GetValueOrDefault("RequestPath")?.ToString();
            if (path is not null)
                return pathsToIgnore.Any(p => path.StartsWith(p));
            return false;
        };
    }
}