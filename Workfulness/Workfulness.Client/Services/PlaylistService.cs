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

        public PlaylistService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }

        public async Task<Playlist> GetPlaylistAsync(int id)
        {
            var playlist = await _HttpClient.GetFromJsonAsync<Playlist>($"playlist/{id}");
            return playlist;
        }

        public async Task<List<PlaylistGroup>> GetCategorizedPlaylistsAsync()
        {
            var playlistsGroups = new List<PlaylistGroup>();
            var categories = await _HttpClient.GetFromJsonAsync<List<string>>($"playlist/category");
            foreach (var category in categories)
            {
                var playlists = await _HttpClient.GetFromJsonAsync<List<Playlist>>($"playlist/?playlistCategory={category}");
                playlistsGroups.Add(new PlaylistGroup()
                {
                    Category = category,
                    Playlists = playlists
                });
            }

            return playlistsGroups;
        }
    }
}
