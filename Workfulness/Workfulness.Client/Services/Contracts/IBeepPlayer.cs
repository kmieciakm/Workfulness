using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Services.Contracts
{
    public interface IBeepPlayer
    {
        Task PlayBeep(string songSource);

        event Action BeepHasFinished;
    }
}
