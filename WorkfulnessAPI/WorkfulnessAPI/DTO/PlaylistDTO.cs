using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.DTO
{
    public record PlaylistDTO(string Title, string CoverUrl, List<SongDTO> Songs)
    {
        public PlaylistDTO(Playlist playlist) : this(playlist.Title, playlist.CoverUrl, MapToSongsDTO(playlist.Songs)) { }

        private static List<SongDTO> MapToSongsDTO(List<Song> songs)
        {
            return songs.Select(song => new SongDTO(song)).ToList();
        }
    }
}
