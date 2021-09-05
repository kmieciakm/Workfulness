using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Services.Contracts;

namespace Workfulness.Client.Services
{
    public class PageSize : IPageSize
    {
        private IJSRuntime _JSRuntime { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public event Action PageResized;

        public PageSize(IJSRuntime jSRuntime)
        {
            _JSRuntime = jSRuntime;
            _JSRuntime.InvokeVoidAsync("app.setDotnetHelper", DotNetObjectReference.Create(this));
            _JSRuntime.InvokeVoidAsync("app.callResize"); // REMARKS: Initialize Width and Height on start
        }

        public bool IsExtraSmall => Width < 576;

        public bool IsSmall => Width >= 576 && Width < 768;

        public bool IsMedium => Width >= 768 && Width < 992;

        public bool IsLarge => Width >= 992 && Width < 1300;

        public bool IsExtraLarge => Width >= 1300;

        [JSInvokable]
        public void OnPageResized(int width, int height)
        {
            Width = width;
            Height = height;
            PageResized?.Invoke();
        }
    }
}
