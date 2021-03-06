using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Models.Authentication;

namespace WorkfulnessAPI.Services.Ports.Infrastructure
{
    public interface IUserRegistry
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<bool> CreateAsync(User user, string password);
        Task<bool> AuthenticateAsync(string email, string password);
        Task<ValidationResult> ValidatePasswordAsync(string password);
        Task<string> GenerateAccountConfirmationTokenAsync(User user);
        Task<bool> ConfirmationAccountAsync(User user, string confirmationToken);
    }
}
