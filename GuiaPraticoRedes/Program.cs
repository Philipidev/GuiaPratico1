using GuiaPraticoRedes.Extensions;
using GuiaPraticoRedes.Options.Authorization;
using GuiaPraticoRedes.Options.JwtBearer;
using GuiaPraticoRedes.Options.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;
using System.Diagnostics;

try
{
    var builder = WebApplication.CreateBuilder(args);

    SerilogExtension.AddSerilogApi(builder.Configuration, builder.Environment);
    builder.Host.UseSerilog(Log.Logger);
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(CustomSwaggerGenOptions.SetupAction);
    builder.Services
           .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer((configureOptions) => CustomJwtBearerOptions.CustomJwtBearerSetupAction(configureOptions, builder.Configuration));

    builder.Services.AddAuthorization(CustomAuthorizationOptions.SetupAction);

    var app = builder.Build();

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseSwagger();

    app.UseSwaggerUI(CustomSwaggerUIOptions.SetupAction);

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}