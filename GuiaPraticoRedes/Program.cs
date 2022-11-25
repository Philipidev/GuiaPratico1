using GuiaPraticoRedes.Options.Authorization;
using GuiaPraticoRedes.Options.JwtBearer;
using GuiaPraticoRedes.Options.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

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
