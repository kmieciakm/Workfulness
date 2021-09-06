using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WorkfulnessAPI.Middleware
{
    public class ResponseTimer
    {
        private const string RESPONSE_TIME_HEADER = "X-Response-Time-ms";
        private RequestDelegate _NextMiddleware { get; }

        public ResponseTimer(RequestDelegate nextMiddleware)
        {
            _NextMiddleware = nextMiddleware;
        }

        public Task InvokeAsync(HttpContext context)
        {
            var watch = new Stopwatch();
            watch.Start();
            context.Response.OnStarting(() => {
                watch.Stop();
                var requestCompletionTime = watch.ElapsedMilliseconds;
                context.Response.Headers.Add(RESPONSE_TIME_HEADER, requestCompletionTime.ToString());
                return Task.CompletedTask;
            });
            return _NextMiddleware(context);
        }
    }
}
