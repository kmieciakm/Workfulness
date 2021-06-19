using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.DTO
{
    public record ToDoDTO(string name, IEnumerable<TaskItemDTO> tasks)
    {
        public ToDoDTO(ToDoList toDo)
            : this(toDo.Name, toDo.Tasks.Select(task => new TaskItemDTO(task))) { }
    }

    public record TaskItemDTO(string task, DateTime dueDate, bool done)
    {
        public TaskItemDTO(TaskItem task)
            : this(task.Task, task.DueDate, task.Done) {}
    }
}
