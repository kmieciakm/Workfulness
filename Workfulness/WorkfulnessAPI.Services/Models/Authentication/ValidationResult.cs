using System;
using System.Collections.Generic;
using System.Text;

namespace WorkfulnessAPI.Services.Models.Authentication
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = true;
        public List<string> Errors { get; set; } = new List<string>();
    }
}
