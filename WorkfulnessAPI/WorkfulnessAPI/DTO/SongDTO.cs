using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.DTO
{
    public record SongDTO(int Id, string Title, string Author, string Url)
    {
        public SongDTO(Song song) : this(song.Id, song.Title, song.Author, song.Url) { }
    };
}
