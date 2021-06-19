using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services
{
    public class ToDoListService : ITodoListService
    {
        private IToDoListRegistry _ToDoRegistry { get; set; }

        public ToDoListService(IToDoListRegistry toDoRegistry)
        {
            _ToDoRegistry = toDoRegistry;
        }

        public List<ToDoList> GetListsOfUser(Guid userId)
        {
            return _ToDoRegistry.FindByOwner(userId).ToList();
        }
    }
}
