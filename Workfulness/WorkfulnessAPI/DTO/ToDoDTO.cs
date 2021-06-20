using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.DTO
{
    public record ToDoDTO(string Name, IEnumerable<TaskItemDTO> Tasks)
    {
        public ToDoDTO(ToDoList toDo) : this(toDo.Name, toDo.Tasks.Select(task => new TaskItemDTO(task))) { }
    }

    public record TaskItemDTO(string Task, DateTime DueDate, bool Done)
    {
        public TaskItemDTO(TaskItem task) : this(task.Task, task.DueDate, task.Done) { }

        [JsonConstructor]
        public TaskItemDTO(string task, DateTime dueDate) : this(task, dueDate, false) { }

        public TaskItem ToTaskItem() => new TaskItem(Task, DueDate);
    }
}
