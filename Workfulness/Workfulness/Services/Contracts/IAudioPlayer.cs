﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Services.Contracts
{
    internal interface IAudioPlayer
    {
        Task Play(string songUrl);
        Task Pause();
        Task Replay();
    }
}
