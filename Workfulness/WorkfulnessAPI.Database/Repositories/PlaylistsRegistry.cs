using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Helpers.Mappers;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;

namespace WorkfulnessAPI.Database.Repositories
{
    public class PlaylistsRegistry : IPlaylistsRegistry
    {
        public DatabaseContext _Database { get; }
        public PlaylistsRegistry(DatabaseContext database)
        {
            _Database = database;
        }

        public Playlist Get(int playlistId)
        {
            var dbPlaylist = _Database.Playlists
                .FirstOrDefault(playlist => playlist.Id == playlistId);
            return Mapper.Playlist.ToPlaylist(dbPlaylist);
        }

        public void Create(Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public void Remove(int playlistId)
        {
            throw new NotImplementedException();
        }

        public void Update(Playlist playlist)
        {
            throw new NotImplementedException();
        }
    }
}
