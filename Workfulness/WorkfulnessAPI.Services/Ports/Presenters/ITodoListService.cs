﻿using System;
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
    }
}
