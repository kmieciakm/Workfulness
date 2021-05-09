using System;
using System.ComponentModel.DataAnnotations;

namespace WorkfulnessAPI.Database.Models
{
    public class DbSong : DbModelBase
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
    }
}
