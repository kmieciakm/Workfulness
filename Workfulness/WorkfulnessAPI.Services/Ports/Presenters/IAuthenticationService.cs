using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Models.Authentication;

namespace WorkfulnessAPI.Services.Ports.Presenters
{
    public interface IAuthenticationService
    {
        Task<User> GetIdentity(string email);
        Task<string> SignInAsync(SignIn signIn);
        Task<User> SignUpAsync(SignUp signUp);
        Task ConfirmAccountAsync(ConfirmAccount confirmation);
    }
}
