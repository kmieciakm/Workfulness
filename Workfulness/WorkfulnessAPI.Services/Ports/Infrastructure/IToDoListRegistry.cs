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
        void AddListToUser(Guid userId, ToDoList list);
    }
}
