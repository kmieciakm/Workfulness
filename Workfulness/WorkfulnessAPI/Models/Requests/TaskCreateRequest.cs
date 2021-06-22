using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Models.Requests
{
    public class TaskCreateRequest
    {
        public string Task { get; set; }
        public DateTime DueDate { get; set; }

        public TaskItem ToTaskItem() => new TaskItem(Task, DueDate);
    }
}
