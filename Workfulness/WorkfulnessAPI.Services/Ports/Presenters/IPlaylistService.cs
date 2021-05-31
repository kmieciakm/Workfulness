using System.Collections.Generic;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Presenters
{
    public interface IPlaylistService
    {
        IEnumerable<Playlist> GetPlaylists();
        Playlist GetPlaylistById(int id);
        IEnumerable<string> GetAvailablePlaylistsCategories();
        IEnumerable<Playlist> GetPlaylistsOfCategory(string category);
    }
}