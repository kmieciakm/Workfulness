using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models;

namespace Workfulness.Client.Services.Contracts
{
    public interface IToDoService
    {
        Task<List<ToDoList>> GetToDoListsAsync();
        Task CreateToDoList(string name);
        Task DeleteToDoList(string name);
    }
}
