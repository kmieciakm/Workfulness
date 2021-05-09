using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Services.Contracts
{
    public interface IPomodoroTimer
    {
        int Minutes { get; }
        int Seconds { get; }
        string ShortTime { get; }
        bool HasRun { get; }

        void SetTime(int minutesToSet);
        void StartCount();
        void StopCount();

        event Action OnTick;
        event Action OnFinished;
    }
}
