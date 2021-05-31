using System;
using System.Collections.Generic;
using System.Text;

namespace WorkfulnessAPI.Services.Models.Authentication
{
    public class ConfirmAccount
    {
        public User User { get; set; }
        public string ConfirmationToken { get; set; }
    }
}
