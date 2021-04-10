using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Database.Models
{
    public abstract class DbModelBase
    {
        [Key]
        public int Id { get; set; }
    }
}
