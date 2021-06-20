using System;
using System.Collections.Generic;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Infrastructure
{
    public interface IPlaylistsRegistry
    {
        public Playlist Get(int playlistId);
        public IEnumerable<Playlist> FindAll();
        public IEnumerable<Playlist> FindByCategory(string category);
        public IEnumerable<Playlist> FindByUser(Guid userId);
        public void Create(Playlist playlist);
        public void CreateFor(Guid userId, Playlist playlist);
        public void Remove(int playlistId);
        public void Update(Playlist playlist);
        public IEnumerable<string> GetCategories();
    }
}
