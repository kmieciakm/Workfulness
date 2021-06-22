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
        public int Id { get; set; }

        [JsonConstructor]
        public TaskItemDTO(int id, string task, DateTime dueDate, bool done) : this(task, dueDate, done)
        {
            Id = id;
        }

        public TaskItemDTO(TaskItem task) : this(task.Id, task.Task, task.DueDate, task.Done) { }

        public TaskItem ToTaskItem() => new TaskItem(Id, Task, DueDate, Done);
    }
}
