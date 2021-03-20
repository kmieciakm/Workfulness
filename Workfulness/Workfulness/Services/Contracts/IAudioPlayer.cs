using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Services.Contracts
{
    internal interface IAudioPlayer
    {
        bool IsSongPlaying { get; }
        Task AttachSong(string songSrc);
        Task Play();
        Task Pause();
        /// <summary>
        /// Set track current playing time to given song duration percentage.
        /// </summary>
        /// <param name="percent"></param>
        Task SetTrackAtTime(int percent);
        /// <summary>
        /// Get elapsed time of a song duration.
        /// </summary>
        /// <returns>Elapsed percentage time of a song.</returns>
        Task<int> GetElapsedTime();
    }
}
