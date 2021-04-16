using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Workfulness.Client.Models;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    class PlaylistService : IPlaylistService
    {
        private HttpClient _HttpClient { get; }

        public PlaylistService(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient("GatewayAPI");
            _HttpClient.BaseAddress = new Uri("https://localhost:44300/"); // BUG, TODO: Check why client is injected without BaseAddress
            Console.WriteLine($"API: {_HttpClient.BaseAddress}");
        }

        public async Task<Playlist> GetPlaylistAsync(int id)
        {
            var playlist = await _HttpClient.GetFromJsonAsync<Playlist>($"playlist/{id}");
            return playlist;
        }
    }
}
