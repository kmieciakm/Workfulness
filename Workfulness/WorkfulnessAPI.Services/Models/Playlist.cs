using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public class Playlist {
        public Playlist(int id, string title, string coverUrl, string category, IEnumerable<Song> songs)
        {
            Id = id;
            Title = title;
            CoverUrl = coverUrl;
            Category = category;
            Songs = songs;
        }

        public int Id { get; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Category { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}
