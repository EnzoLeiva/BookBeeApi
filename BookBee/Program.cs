using BookBee.Api;
using BookBee.Application;
using BookBee.Common;
using BookBee.External;
using BookBee.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

var keyVaultUrl = builder.Configuration["keyVaultUrl"] ?? string.Empty;

//if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
//{
//    string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
//    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
//    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

//    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), tokenCredentials);
//}
//else
//{
//    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
//}

builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
