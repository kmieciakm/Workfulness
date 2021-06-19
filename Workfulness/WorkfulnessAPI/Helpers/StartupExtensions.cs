using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Models;
using WorkfulnessAPI.Database.Repositories;
using WorkfulnessAPI.Services.Models.Config;
using WorkfulnessAPI.Services.Ports.Infrastructure;
using WorkfulnessAPI.Services.Ports.Presenters;
using WorkfulnessAPI.Services.Services;

namespace WorkfulnessAPI.Helpers
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DatabaseContext>(options => options
                .UseSqlServer(connectionString))
                .AddIdentity<DbUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddTokenProvider<DataProtectorTokenProvider<DbUser>>(TokenOptions.DefaultProvider);
            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SongsConfig>(configuration.GetSection("SongsConfig"));
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            // Database Repositories
            services.AddScoped<IPlaylistsRegistry, PlaylistsRegistry>();
            services.AddScoped<ISongsRegistry, SongsRegistry>();
            services.AddScoped<IUserRegistry, UserRegistry>();
            services.AddScoped<IToDoListRegistry, ToDoRepository>();

            // Domain Services
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<ITodoListService, ToDoListService>();

            return services;
        }

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
