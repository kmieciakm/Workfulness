using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workfulness.Client.Models.Auth
{
    public class RegisterRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
    }
}
