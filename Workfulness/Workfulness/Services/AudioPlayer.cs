using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Services.Contracts;

namespace Workfulness.Services
{
    internal class AudioPlayer : IAudioPlayer
    {
        private IJSRuntime _JSRuntime { get; set; }

        public AudioPlayer(IJSRuntime jsRuntime)
        {
            _JSRuntime = jsRuntime;
        }

        public async Task Play(string songUrl) 
            => await _JSRuntime.InvokeVoidAsync("play", songUrl);

        public async Task Pause() =>
            await _JSRuntime.InvokeVoidAsync("pause");

        public async Task Replay() =>
            await _JSRuntime.InvokeVoidAsync("replay");

        public async Task SetTrackAtTime(int percent) =>
            await _JSRuntime.InvokeVoidAsync("setTrackAtTime", percent);
    }
}
