using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [Authorize]
    [UserFilter]
    public abstract class AuthorizedControllerBase : ControllerBase
    {
        public User CurrentUser { get; set; }

        private class UserFilterAttribute : TypeFilterAttribute
        {
            public UserFilterAttribute() : base(typeof(UserFilter))
            {
            }
        }

        private class UserFilter : IAsyncActionFilter
        {
            private IAuthenticationService _AuthenticationService { get; }

            public UserFilter(IAuthenticationService authenticationService)
            {
                _AuthenticationService = authenticationService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var controller = context.Controller as AuthorizedControllerBase;
                var email = controller.User.FindFirst(ClaimTypes.Email)?.Value;
                var user = await _AuthenticationService.GetIdentity(email);

                if (user == null)
                {
                    context.Result = new ConflictResult();
                    return;
                }
                else
                {
                    controller.CurrentUser = user;
                }

                await next();
            }
        }
    }
}
