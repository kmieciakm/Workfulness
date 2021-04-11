using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services
{
    public class PlaylistService : IPlaylistService
    {
        public IPlaylistsRegistry _PlaylistRegistry { get; set; }

        public PlaylistService(IPlaylistsRegistry playlistsRegistry)
        {
            _PlaylistRegistry = playlistsRegistry;
        }

        public Playlist GetPlaylistById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Playlist> GetPlaylists()
        {
            throw new NotImplementedException();
        }
    }
}
