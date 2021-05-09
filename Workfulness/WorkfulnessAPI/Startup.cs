using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Seed;
using WorkfulnessAPI.Helpers;

namespace WorkfulnessAPI
{
    public class Startup
    {
        private string _corsPolicyName { get { return "CustomAllowSpecificOrigins"; } }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                string[] origins = Configuration
                    .GetSection("AllowedOrigins")
                    .Get<string[]>();

                options.AddPolicy(_corsPolicyName, builder =>
                {
                    builder.WithOrigins(origins)
                       .WithMethods("POST")
                       .WithHeaders("Content-Type");
                });
            });

            services.AddControllers();

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "WorkfulnessAPI", Version = "v1" });
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                config.IncludeXmlComments(xmlCommentsPath);
            });

            services.AddDatabase(Configuration.GetConnectionString("DefaultConnection"))
                    .AddTokenAuthentication(Configuration)
                    .AddOptions(Configuration)
                    .AddCustomServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkfulnessAPI v1"));

                var seedDatabase = new DatabaseSeed(
                        serviceProvider.GetRequiredService<DatabaseContext>());
                seedDatabase.Seed();
            }

            app.UseHttpsRedirection();
            app.UseCors(_corsPolicyName);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
