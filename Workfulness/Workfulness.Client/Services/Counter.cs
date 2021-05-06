using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    public class Counter : ICounter
    {
        public event Action OnTick;

        private int _TimeLeft { get; set; }
        private Timer _Timer { get; set; }

        private const int secondsInMinute = 60;
       
        public int Minutes { get { return _TimeLeft / secondsInMinute; } }
        public int Seconds { get { return _TimeLeft % secondsInMinute; } }
        public bool TimeUp { get { return _TimeLeft == 0; } }

        public Counter(int minutesToCount) 
        {
            _Timer = new Timer(1000);
            SetTime(minutesToCount);
           _Timer.Elapsed += Timer_Elapsed;
        }
        public void StartCount()
        {
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
            StartCount();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _TimeLeft--;
            OnTick?.Invoke();
        }
    }
}
