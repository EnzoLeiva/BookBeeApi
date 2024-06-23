using BookBee.Application.DataBase;
using BookBee.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookBee.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SQLConnectionString");
            services.AddDbContext<DataBaseService>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BookBee.Api")));  //En un futuro cambiar la carpeta de las migraciones a Persistence
            services.AddScoped<IDataBaseService, DataBaseService>();

            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "local")
            //{
            //    string tenantId = Environment.GetEnvironmentVariable("tenantId") ?? string.Empty;
            //    string clientId = Environment.GetEnvironmentVariable("clientId") ?? string.Empty;
            //    string clientSecret = Environment.GetEnvironmentVariable("clientSecret") ?? string.Empty;

            //    var tokenCredentials = new ClientSecretCredential(tenantId, clientId, clientSecret);

            //    var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(tokenCredentials);

            //    SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
            //        SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
            //    {
            //        {SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider }
            //    });

            //}
            //else
            //{
            //    var azureKeyVaultProvider = new SqlColumnEncryptionAzureKeyVaultProvider(new ManagedIdentityCredential());

            //    SqlConnection.RegisterColumnEncryptionKeyStoreProviders(new Dictionary<string,
            //        SqlColumnEncryptionKeyStoreProvider>(1, StringComparer.OrdinalIgnoreCase)
            //    {
            //        {SqlColumnEncryptionAzureKeyVaultProvider.ProviderName, azureKeyVaultProvider }
            //    });
            //}

            return services;
        }
    }
}
