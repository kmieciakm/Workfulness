using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Database.Models
{
    public class DbTaskItem : DbModelBase
    {
        [Required]
        [MaxLength(500)]
        public string Task { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
    }
}
