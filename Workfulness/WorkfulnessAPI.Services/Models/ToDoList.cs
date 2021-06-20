using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Services.Models
{
    public class ToDoList
    {
        public string Name { get; set; }
        public List<TaskItem> Tasks { get; set; }

        public ToDoList(string name)
        {
            Name = name;
            Tasks = new List<TaskItem>();
        }

        public ToDoList(string name, List<TaskItem> tasks)
        {
            Name = name;
            Tasks = tasks;
        }
    }
}
