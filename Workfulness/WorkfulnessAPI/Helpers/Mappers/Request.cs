using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Models.Requests;
using WorkfulnessAPI.Services.Models.Authentication;

namespace WorkfulnessAPI.Helpers.Mappers
{
    public static partial class Mapper
    {
        public static class Request
        {
            public static SignIn ToSignIn(SignInRequest signInRequest)
            {
                return new SignIn()
                {
                    Email = signInRequest.Email,
                    Password = signInRequest.Password
                };
            }

            public static SignUp ToSignUp(SignUpRequest signUpRequest)
            {
                return new SignUp()
                {
                    Firstname = signUpRequest.Firstname,
                    Lastname = signUpRequest.Lastname,
                    Email = signUpRequest.Email,
                    Password = signUpRequest.Password,
                    ConfirmationPassword = signUpRequest.ConfirmationPassword
                };
            }
        }
    }
}
