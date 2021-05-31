using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Helpers.Mappers;
using WorkfulnessAPI.Database.Models;
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
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .FirstOrDefault(playlist => playlist.Id == playlistId);
            return Mapper.Playlist.ToPlaylist(dbPlaylist);
        }

        public IEnumerable<Playlist> FindAll()
        {
            var dbPlaylists = _Database.Playlists
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .Where(_ => true);
            return Mapper.Playlist.ToPlaylist(dbPlaylists);
        }

        public IEnumerable<Playlist> FindByCategory(string category)
        {
            var dbPlaylists = _Database.Playlists
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .Where(playlist => playlist.Category.Name == category);
            return Mapper.Playlist.ToPlaylist(dbPlaylists);
        }

        public void Create(Playlist playlist)
        {
            var dbPlaylist = Mapper.Playlist.ToDbPlaylist(playlist);
            var dbCategory = _Database.PlaylistsCategories
                .FirstOrDefault(category => category.Name == playlist.Category);

            if (dbCategory != null)
            {
                dbPlaylist.CategoryId = dbCategory.Id;
                dbPlaylist.Category = null;
            }

            _Database.Add(dbPlaylist);
        }

        public void Remove(int playlistId)
        {
            var playlistToRemove = Get(playlistId);
            if (playlistToRemove != null)
            {
                _Database.Remove(playlistToRemove);
            }
        }

        public void Update(Playlist playlist)
        {
            var dbPlaylist = Mapper.Playlist.ToDbPlaylist(playlist);
            var dbCategory = _Database.PlaylistsCategories
                .FirstOrDefault(category => category.Name == playlist.Category);

            if (dbCategory != null)
            {
                dbPlaylist.CategoryId = dbCategory.Id;
                dbPlaylist.Category = null;
            }

            _Database.Update(dbPlaylist);
        }

        public IEnumerable<string> GetCategories()
        {
            return _Database.PlaylistsCategories
                .Select(category => category.Name);
        }
    }
}
