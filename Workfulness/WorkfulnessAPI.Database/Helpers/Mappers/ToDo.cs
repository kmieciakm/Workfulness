using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Models;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Database.Helpers.Mappers
{
    public static partial class Mapper
    {
        public static class ToDo
        {
            public static ToDoList FromDbList(DbToDoList dbToDo)
            {
                return new ToDoList(
                        dbToDo.Name,
                        FromDbTask(dbToDo.Tasks).ToList()
                    );
            }

            public static IEnumerable<ToDoList> FromDbList(IEnumerable<DbToDoList> dbToDo)
            {
                return dbToDo.Select(toDo => FromDbList(toDo));
            }

            public static TaskItem FromDbTask(DbTaskItem dbTask)
            {
                return new TaskItem(dbTask.Task, dbTask.DueDate, dbTask.Done);
            }

            public static IEnumerable<TaskItem> FromDbTask(IEnumerable<DbTaskItem> dbTasks)
            {
                return dbTasks.Select(task => FromDbTask(task));
            }
        }
    }
}
