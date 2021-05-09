using System;
using System.Collections.Generic;
using System.Text;

namespace WorkfulnessAPI.Services.Models.Config
{
    public class AuthenticationConfig
    {
        public string Secret { get; set; }
        public int ExpirationHours { get; set; }
    }
}
