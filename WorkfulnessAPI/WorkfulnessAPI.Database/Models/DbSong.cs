using System;
using System.ComponentModel.DataAnnotations;

namespace WorkfulnessAPI.Database.Models
{
    public class DbSong : DbModelBase
    {
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        [Required]
        public string SongUrl { get; set; }
    }
}
