using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models
{
    public class ToDoList
    {
        public string Name { get; set; }
        private IEnumerable<ToDoTask> _tasks;
        public IEnumerable<ToDoTask> Tasks
        {
            get
            {
                return _tasks
                    .OrderBy(task => task.Done)
                    .ThenBy(task => task.DueDate)
                    .ThenBy(task => task.Task);
            }
            init
            {
                _tasks = value;
            }
        }

        public void DisableAllTasksEditMode()
        {
            foreach (var task in _tasks)
            {
                task.InEditMode = false;
            }
        }
    }
}
