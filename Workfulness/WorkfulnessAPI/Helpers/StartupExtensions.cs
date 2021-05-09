using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models.Config;

namespace WorkfulnessAPI.Helpers
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("AuthenticationConfig");
            var settings = settingsSection.Get<AuthenticationConfig>();
            var key = Encoding.ASCII.GetBytes(settings.Secret);

            services
                .Configure<AuthenticationConfig>(settingsSection)
                .AddAuthentication(authOptions =>
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(authOptions =>
                {
                    authOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            return services;
        }
    }
}
