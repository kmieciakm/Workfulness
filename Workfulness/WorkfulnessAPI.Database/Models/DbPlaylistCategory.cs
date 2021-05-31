using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Database.Models
{
    public class DbPlaylistCategory
    {
        [Key]
        public int? Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
    }
}
