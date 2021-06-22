using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Helpers.Mappers;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;

namespace WorkfulnessAPI.Database.Repositories
{
    public class ToDoRegistry : IToDoListRegistry
    {
        public DatabaseContext _Database { get; }
        public ToDoRegistry(DatabaseContext database)
        {
            _Database = database;
        }

        public IEnumerable<ToDoList> FindByOwner(Guid userId)
        {
            var dbToDos = _Database.ToDoLists
                .Include(toDoList => toDoList.Tasks)
                .Where(toDo => toDo.OwnerId == userId.ToString());
            return Mapper.ToDo.FromDbList(dbToDos);
        }

        public void AddListToUser(Guid userId, ToDoList list)
        {
            var dbToDo = Mapper.ToDo.ToDbList(list);
            dbToDo.OwnerId = userId.ToString();
            dbToDo.Owner = null;
            _Database.ToDoLists.Add(dbToDo);
            _Database.SaveChanges();
        }

        public ToDoList FindByName(Guid userId, string listName)
        {
            var dbToDos = _Database.ToDoLists
                .Include(toDoList => toDoList.Tasks)
                .Where(toDo => toDo.OwnerId == userId.ToString())
                .FirstOrDefault(toDo => toDo.Name == listName);
            return Mapper.ToDo.FromDbList(dbToDos);
        }

        public void AddTasksToList(Guid userId, string listName, IEnumerable<TaskItem> tasks)
        {
            var list = _Database.ToDoLists
                .Include(toDoList => toDoList.Tasks)
                .Where(toDo => toDo.OwnerId == userId.ToString())
                .FirstOrDefault(l => l.Name == listName);

            var dbTasks = Mapper.ToDo.ToDbTask(tasks);

            if (list != null)
            {
                list.Tasks = list.Tasks.Concat(dbTasks).ToList();
                _Database.Entry(list).State = EntityState.Modified;
            }
            _Database.SaveChanges();
        }

        public void ReplaceTasks(Guid userId, string listName, IEnumerable<TaskItem> tasks)
        {
            var list = _Database.ToDoLists
               .Include(toDoList => toDoList.Tasks)
               .Where(toDo => toDo.OwnerId == userId.ToString())
               .FirstOrDefault(l => l.Name == listName);

            var dbTasks = Mapper.ToDo.ToDbTask(tasks).ToList();

            if (list != null)
            {
                list.Tasks = dbTasks;
            }
            _Database.SaveChanges();
        }

        public void DeleteList(Guid userId, string listName)
        {
            if (Exists(userId, listName))
            {
                var list = _Database.ToDoLists
                    .Where(toDo => toDo.OwnerId == userId.ToString())
                    .FirstOrDefault(l => l.Name == listName);

                _Database.ToDoLists.Remove(list);
                _Database.SaveChanges();
            }
        }

        public void DeleteTask(Guid userId, string listName, int taskId)
        {
            if (Exists(userId, listName))
            {
                var list = _Database.ToDoLists
                    .Where(toDo => toDo.OwnerId == userId.ToString())
                    .FirstOrDefault(l => l.Name == listName);

                list.Tasks = list.Tasks.Where(task => task.Id != taskId).ToList();
                _Database.SaveChanges();
            }
        }

        public bool Exists(Guid userId, string listName)
        {
            return FindByOwner(userId).Any(list => list.Name == listName);
        }
    }
}
