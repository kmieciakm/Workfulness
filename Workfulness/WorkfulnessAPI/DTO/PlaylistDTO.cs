using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.DTO
{
    public record PlaylistDTO(string Title, string CoverUrl, List<SongDTO> Songs)
    {
        public PlaylistDTO(Playlist playlist, string baseSongUrl)
            : this(playlist.Title, playlist.CoverUrl, MapToSongsDTO(playlist.Songs, baseSongUrl)) { }

        private static List<SongDTO> MapToSongsDTO(IEnumerable<Song> songs, string baseSongUrl)
        {
            return songs.Select(song => new SongDTO(song, baseSongUrl)).ToList();
        }
    }
}
