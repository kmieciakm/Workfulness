using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Workfulness.Client.Models;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    public class PomodoroTimer : IPomodoroTimer
    {
        public event Action OnTick;
        public event Action OnFinished;
        public event Action OnWorkStarted;
        public event Action OnShortBreakStarted;
        public event Action OnLongBreakStarted;

        private int _TimeLeft { get; set; }
        private Timer _Timer { get; set; }

        private const int secondsInMinute = 60;
       
        public int Minutes { get { return _TimeLeft / secondsInMinute; } }
        public int Seconds { get { return _TimeLeft % secondsInMinute; } }
        public string ShortTime { get {
                string minutes = Minutes >= 10 ? Minutes.ToString() : $"0{Minutes}";
                string seconds = Seconds >= 10 ? Seconds.ToString() : $"0{Seconds}";
                return $"{minutes}:{seconds}";
            }
        }

        public bool HasRun { get; private set; } = false;

        public PomodoroState CurrentState { get; private set; }

        public PomodoroTimer(int minutesToCount) 
        {
            _Timer = new Timer(1000);
            _Timer.Elapsed += Timer_Elapsed;
            _Timer.Enabled = false;
            WorkSession(minutesToCount);
        }
        public void StartCount()
        {
            HasRun = true;
            _Timer.Start();
        }

        public void StopCount()
        {
            _Timer.Stop();
        }

        private void SetTime(int minutesToSet)
        {
            StopCount();
            _TimeLeft = minutesToSet * secondsInMinute;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _TimeLeft--;
            if (_TimeLeft <= 0)
            {
                _Timer.Stop();
                OnFinished?.Invoke();
            }
            OnTick?.Invoke();
        }

        public void WorkSession(int minutes)
        {
            SetTime(minutes);
            OnWorkStarted?.Invoke();
            CurrentState = PomodoroState.WORK;
        }

        public void ShortBreakSession(int minutes)
        {
            SetTime(minutes);
            OnShortBreakStarted?.Invoke();
            CurrentState = PomodoroState.SHORT_BREAK;
        }

        public void LongBreakSession(int minutes)
        {
            SetTime(minutes);
            OnLongBreakStarted?.Invoke();
            CurrentState = PomodoroState.LONG_BREAK;
        }
    }
}
