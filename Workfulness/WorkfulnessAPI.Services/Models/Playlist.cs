using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public class Playlist {
        public Playlist(int id, string title, string coverUrl, string category, IEnumerable<Song> songs, bool isPublic = true)
        {
            Id = id;
            Title = title;
            CoverUrl = coverUrl;
            Category = category;
            Songs = songs;
            IsPublic = isPublic;
        }

        public Playlist(string title, string coverUrl, string category, IEnumerable<Song> songs, bool isPublic = true)
        {
            Title = title;
            CoverUrl = coverUrl;
            Category = category;
            Songs = songs;
            IsPublic = isPublic;
        }

        public static Playlist CreateFavouritesPlaylist()
        {
            return new Playlist(
                    "Favourites",
                    @"https://images.pexels.com/photos/4197491/pexels-photo-4197491.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=650&w=940",
                    "Private",
                    new List<Song>(),
                    false
                );
        }

        public int Id { get; }
        public string Title { get; set; }
        public string CoverUrl { get; set; }
        public string Category { get; set; }
        public bool IsPublic { get; set; } = true;
        public IEnumerable<Song> Songs { get; set; }
    }
}
