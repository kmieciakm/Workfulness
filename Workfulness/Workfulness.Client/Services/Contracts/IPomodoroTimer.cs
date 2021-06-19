using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models;

namespace Workfulness.Client.Services.Contracts
{
    public interface IPomodoroTimer
    {
        int Minutes { get; }
        int Seconds { get; }
        string ShortTime { get; }
        bool HasRun { get; }
        PomodoroState CurrentState { get; }

        void StartCount();
        void StopCount();
        void WorkSession(int minutes);
        void ShortBreakSession(int minutes);
        void LongBreakSession(int minutes);

        event Action OnTick;
        event Action OnFinished;
        event Action OnWorkStarted;
        event Action OnShortBreakStarted;
        event Action OnLongBreakStarted;
    }
}
