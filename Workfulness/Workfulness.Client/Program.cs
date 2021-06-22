using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
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
using Workfulness.Client.Services.Auth;
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
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(gatewayApiUrl) });

            ConfigureServices(builder.Services);

            await builder.Build().RunAsync();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();

            // Authorization
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

            // Internal services
            services.AddSingleton<IPageSize, PageSize>();
            services.AddScoped<IAudioPlayer, AudioPlayer>();
            services.AddScoped<IBeepPlayer, BeepPlayer>();
            services.AddScoped<IPlaylistManager, PlaylistManager>();
            services.AddSingleton<IPomodoroTimer>(_ => new PomodoroTimer(25));

            // External
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
