using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Exceptions;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services
{
    public class ToDoListService : ITodoListService
    {
        private IToDoListRegistry _ToDoRegistry { get; set; }
        private IUserRegistry _UserRegistry { get; set; }

        public ToDoListService(IToDoListRegistry toDoRegistry, IUserRegistry userRegistry)
        {
            _ToDoRegistry = toDoRegistry;
            _UserRegistry = userRegistry;
        }

        public List<ToDoList> GetListsOfUser(Guid userId)
        {
            return _ToDoRegistry.FindByOwner(userId).ToList();
        }

        public ToDoList CreateNewList(Guid userId, string listName)
        {
            var user = _UserRegistry.GetAsync(userId).Result;
            if (user == null)
            {
                throw new ToDoException($"Cannot create list. User of id {userId} does not exists.", ExceptionCause.IncorrectInputData);
            }

            try
            {
                var toDoList = new ToDoList(listName);
                _ToDoRegistry.AddListToUser(userId, toDoList);
                return toDoList;
            }
            catch (Exception ex)
            {
                throw new ToDoException($"Cannot create list. See inner exception for more information.", ex, ExceptionCause.Unknown);
            }
        }
    }
}
