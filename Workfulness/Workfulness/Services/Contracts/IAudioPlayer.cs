using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Services.Contracts
{
    public interface IAudioPlayer
    {
        public Task Play(string songUrl);
        public Task Pause();
        public Task Replay();
    }
}
