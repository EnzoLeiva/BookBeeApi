using BookBee.Application.External.ApplicationInsights;
using BookBee.Application.External.GetTokenJwt;
using BookBee.Application.External.Password;
using BookBee.Application.External.SendGridEmail;
using BookBee.External.ApplicationInsights;
using BookBee.External.GetTokenJwt;
using BookBee.External.Password;
using BookBee.External.SendGridEmail;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookBee.External
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<ISendGridEmailService, SendGridEmailService>();
            services.AddSingleton<IGetTokenJwtService, GetTokenJwtService>();
            services.AddSingleton<IPasswordService, PasswordService>();
            IConfigurationSection jwtSettings = configuration.GetSection("Authentication:JwtSettings");
            string key = jwtSettings["SecretKeyJwt"];
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                IConfigurationSection jwtSettings = configuration.GetSection("Authentication:JwtSettings");
                string key = jwtSettings["SecretKeyJwt"];

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["IssuerJwt"],
                    ValidAudience = jwtSettings["AudienceJwt"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            //Ver porque no funciona jwt y google juntos

            //// Configuración de JWT y Google auth
            //var jwtSettings = builder.Configuration.GetSection("Authentication:JwtSettings");
            //string key = jwtSettings["SecretKeyJwt"];
            //builder.Services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = jwtSettings["IssuerJwt"],
            //        ValidAudience = jwtSettings["AudienceJwt"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
            //    };
            //})
            //.AddCookie()
            //.AddGoogle(options =>
            //{
            //    IConfigurationSection googleAuthNSection =
            //        builder.Configuration.GetSection("Authentication:Google");

            //    options.ClientId = googleAuthNSection["ClientId"];
            //    options.ClientSecret = googleAuthNSection["ClientSecret"];
            //});

            services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
            {
                ConnectionString = configuration["ApplicationInsightsConnectionString"]
            });

            services.AddSingleton<IInsertApplicationInsightsService, InsertApplicationInsightsService>();

            return services;
        }
    }
}
