using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Database.Models
{
    public class DbToDoList : DbModelBase
    {
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public DbUser Owner { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public IEnumerable<DbTaskItem> Tasks { get; set; }
    }
}
