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
    public class ToDoRepository : IToDoListRegistry
    {
        public DatabaseContext _Database { get; }
        public ToDoRepository(DatabaseContext database)
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
    }
}
