using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Database.Models
{
    public class DbPlaylist : DbModelBase
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string CoverUrl { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public DbPlaylistCategory Category { get; set; }
        public IEnumerable<DbSong> Songs { get; set; }
    }
}
