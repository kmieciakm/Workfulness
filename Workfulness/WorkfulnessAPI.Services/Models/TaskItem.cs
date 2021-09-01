using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime? DueDate { get; set; }
        public bool Done { get; set; }

        public TaskItem(string task)
        {
            Task = task;
            DueDate = null;
            Done = false;
        }

        public TaskItem(int id, string task, DateTime? dueDate, bool done)
        {
            Id = id;
            Task = task;
            DueDate = dueDate;
            Done = done;
        }
    }
}
