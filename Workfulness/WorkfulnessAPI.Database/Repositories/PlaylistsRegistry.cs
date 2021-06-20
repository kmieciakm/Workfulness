using Microsoft.AspNetCore.Identity;
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
        public UserManager<DbUser> _UserManager { get; }
        public PlaylistsRegistry(DatabaseContext database, UserManager<DbUser> userManager)
        {
            _Database = database;
            _UserManager = userManager;
        }

        public Playlist Get(int playlistId)
        {
            var dbPlaylist = _Database.Playlists
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .FirstOrDefault(playlist => playlist.Id == playlistId && playlist.IsPublic);
            return Mapper.Playlist.ToPlaylist(dbPlaylist);
        }

        public IEnumerable<Playlist> FindAll()
        {
            var dbPlaylists = _Database.Playlists
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .Where(playlist => playlist.IsPublic);
            return Mapper.Playlist.ToPlaylist(dbPlaylists);
        }

        public IEnumerable<Playlist> FindByCategory(string category)
        {
            var dbPlaylists = _Database.Playlists
                .Include(playlist => playlist.Songs)
                .Include(playlist => playlist.Category)
                .Where(playlist => playlist.Category.Name == category && playlist.IsPublic);
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

        private DbPlaylist CreateAndGet(Playlist playlist)
        {
            var dbPlaylist = Mapper.Playlist.ToDbPlaylist(playlist);
            var dbCategory = _Database.PlaylistsCategories
                .FirstOrDefault(category => category.Name == playlist.Category);

            if (dbCategory != null)
            {
                dbPlaylist.CategoryId = dbCategory.Id;
                dbPlaylist.Category = null;
            }

            return _Database.Add(dbPlaylist).Entity;
        }

        public void CreateFor(Guid userId, Playlist playlist)
        {
            var user = _Database.Users
                .Include(user => user.PrivatePlaylists)
                .FirstOrDefault(user => user.Id == userId.ToString());

            if (user != null)
            {
                var dbPlaylist = CreateAndGet(playlist);
                user.PrivatePlaylists = user.PrivatePlaylists.Concat(new List<DbPlaylist>() { dbPlaylist }).ToList();
                _UserManager.UpdateAsync(user).Wait();
            }
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

        public IEnumerable<Playlist> FindByUser(Guid userId)
        {
            var dbPlaylists = _Database.Users
                .Include(user => user.PrivatePlaylists).ThenInclude(playlist => playlist.Songs)
                .Include(user => user.PrivatePlaylists).ThenInclude(playlist => playlist.Category)
                .FirstOrDefault(user => user.Id == userId.ToString())
                .PrivatePlaylists;
            return Mapper.Playlist.ToPlaylist(dbPlaylists);
        }
    }
}
