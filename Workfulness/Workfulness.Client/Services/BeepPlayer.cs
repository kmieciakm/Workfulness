using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    class BeepPlayer : IBeepPlayer
    {
        private IJSRuntime _JSRuntime { get; set; }
        public event Action BeepHasFinished;

        public BeepPlayer(IJSRuntime jsRuntime) 
        {
            _JSRuntime = jsRuntime;
        }

        public async Task PlayBeep(string songSource)
        {
            await _JSRuntime.InvokeVoidAsync("beepPlayer.playBeep", songSource, DotNetObjectReference.Create(this));
        }

        [JSInvokable]
        public void SongFinished() => BeepHasFinished?.Invoke();
    }
}
