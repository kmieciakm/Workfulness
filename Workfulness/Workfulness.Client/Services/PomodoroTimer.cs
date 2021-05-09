using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
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
        private int _WorkTime { get; set; } = 25;
        private int _ShortBreak { get; set; } = 5;
        private int _LongBreak { get; set; } = 15;

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

        public PomodoroTimer(int minutesToCount) 
        {
            _Timer = new Timer(1000);
            SetTime(minutesToCount);
           _Timer.Elapsed += Timer_Elapsed;
           _Timer.Enabled = false;
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
        public void SetTime(int minutesToSet)
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
            SetTime(_WorkTime);
            OnWorkStarted?.Invoke();
        }

        public void ShortBreakSession(int minutes)
        {
            SetTime(_ShortBreak);
            OnShortBreakStarted?.Invoke();
        }

        public void LongBreakSession(int minutes)
        {
            SetTime(_LongBreak);
            OnLongBreakStarted?.Invoke();
        }
    }
}
