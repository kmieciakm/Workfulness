using System;
using System.Collections.Generic;
using System.Text;

namespace WorkfulnessAPI.Services.Ports.Presenters
{
    public interface ITokenService
    {
        string GenerateSecurityToken(string email);
    }
}
