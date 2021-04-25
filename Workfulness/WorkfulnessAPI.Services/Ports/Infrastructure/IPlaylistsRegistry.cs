using System;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Infrastructure
{
    public interface IPlaylistsRegistry
    {
        public Playlist Get(int playlistId);
        public void Create(Playlist playlist);
        public void Remove(int playlistId);
        public void Update(Playlist playlist);
    }
}
