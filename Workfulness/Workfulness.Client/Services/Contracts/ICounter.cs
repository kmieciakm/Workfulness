using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Services.Contracts
{
    public interface ICounter
    {
        public int Minutes { get; }
        public int Seconds { get; }
        public bool TimeUp { get; }

        public void SetTime(int minutesToSet);
        public void StartCount();
        public void StopCount();

        public event Action OnTick;
    }
}
