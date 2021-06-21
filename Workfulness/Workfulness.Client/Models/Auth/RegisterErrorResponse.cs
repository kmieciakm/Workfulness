using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Workfulness.Client.Models.Auth
{
    public class RegisterErrorResponse
    {
        
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        [JsonProperty(PropertyName = "details")]
        public IEnumerable<string> Details { get; set; }
    }
}
