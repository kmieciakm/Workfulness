using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime DueDate { get; set; }
        public bool Done { get; set; }
        public bool InEditMode { get; set; }
    }
}
