using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Client.Models.Auth;

namespace Workfulness.Client.Services.Auth
{
    interface IAuthenticationService
    {
        Task RegisterUser(RegisterRequest registerRequest);
        Task LoginUser(LoginRequest loginRequest);
        Task Logout();
    }
}
