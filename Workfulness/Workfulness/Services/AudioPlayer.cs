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
        public bool IsSongPlaying { get; private set; }
        public event Action SongHasFinished;

        public AudioPlayer(IJSRuntime jsRuntime)
        {
            _JSRuntime = jsRuntime;
            _JSRuntime.InvokeVoidAsync("audioPlayer.setDotnetHelper", DotNetObjectReference.Create(this));
        }

        public async Task AttachSong(string songSrc) =>
            await _JSRuntime.InvokeVoidAsync("audioPlayer.attachSongToAudio", songSrc);

        public async Task Play()
        {
            await _JSRuntime.InvokeVoidAsync("audioPlayer.play");
            IsSongPlaying = true;
        }

        public async Task Pause()
        {
            await _JSRuntime.InvokeVoidAsync("audioPlayer.pause");
            IsSongPlaying = false;
        }

        public async Task SetTrackAtTime(int percent) =>
            await _JSRuntime.InvokeVoidAsync("audioPlayer.setTrackAtTime", percent);

        public async Task<int> GetElapsedTime() =>
            await _JSRuntime.InvokeAsync<int>("audioPlayer.getElapsedTimeInPercents");

        [JSInvokable]
        public void SongFinished() => SongHasFinished?.Invoke();
    }
}
