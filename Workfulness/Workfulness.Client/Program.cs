using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Workfulness.Client.Services;
using Workfulness.Client.Services.Contracts;
using Workfulness.Client.Services.InMemory;

namespace Workfulness.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var gatewayApiUrl = builder.Configuration.GetValue<string>("ApiUrls:GatewayAPI");

            ConfigureHttpClient(builder.Services, gatewayApiUrl);
            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        private static void ConfigureHttpClient(IServiceCollection services, string gatewayApiUrl)
        {
            services.AddHttpClient("GatewayAPI", client => new HttpClient
            {
                BaseAddress = new Uri(gatewayApiUrl)
            });
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPageSize, PageSize>();
            services.AddScoped<IAudioPlayer, AudioPlayer>();
            services.AddScoped<IPlaylistManager, PlaylistManager>();

            // External
            services.AddSingleton<IPlaylistService, InMemoryPlaylistService>();
            services.AddSingleton<ICounter>(_ => new Counter(25));
        }
    }
}
