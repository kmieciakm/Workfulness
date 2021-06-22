using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Infrastructure
{
    public interface IToDoListRegistry
    {
        IEnumerable<ToDoList> FindByOwner(Guid userId);
        ToDoList FindByName(Guid userId, string listName);
        void AddListToUser(Guid userId, ToDoList list);
        void AddTasksToList(Guid userId, string listName, IEnumerable<TaskItem> tasks);
        void ReplaceTasks(Guid userId, string listName, IEnumerable<TaskItem> tasks);
        void DeleteList(Guid userId, string listName);
        void DeleteTask(Guid userId, string listName, int taskId);
        bool Exists(Guid userId, string listName);
    }
}
