using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Services.Ports.Presenters
{
    public interface ITodoListService
    {
        List<ToDoList> GetListsOfUser(Guid userId);
        ToDoList CreateNewList(Guid userId, string listName);
        void DeleteList(Guid userId, string listName);
        void DeleteTask(Guid userId, string listName, int taskId);
        ToDoList AddTasksToList(Guid userId, string listName, IEnumerable<TaskItem> tasks);
        ToDoList EditTasks(Guid userId, string listName, IEnumerable<TaskItem> tasks);
    }
}
