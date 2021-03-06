using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Models;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Models.Authentication;
using WorkfulnessAPI.Services.Ports.Infrastructure;

namespace WorkfulnessAPI.Database.Repositories
{
    public class UserRegistry : IUserRegistry
    {
        private SignInManager<DbUser> _SignInManager { get; }
        private UserManager<DbUser> _UserManager { get; }

        public UserRegistry(SignInManager<DbUser> signInManager, UserManager<DbUser> userManager)
        {
            _SignInManager = signInManager;
            _UserManager = userManager;
        }

        public async Task<User> GetAsync(Guid id)
        {
            var dbUser = await _UserManager
                .Users
                .FirstOrDefaultAsync(user => user.Id == id.ToString());

            return dbUser?.ToDomainUser();
        }

        public async Task<User> GetAsync(string email)
        {
            var dbUser = await GetDbUserByEmailAsync(email);
            return dbUser?.ToDomainUser();
        }

        private async Task<DbUser> GetDbUserByEmailAsync(string email)
        {
            return await _UserManager
                .Users
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task<bool> CreateAsync(User user, string password)
        {
            var dbUser = new DbUser(user);
            var result = await _UserManager.CreateAsync(dbUser, password);

            return result.Succeeded;
        }

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            var user = await GetDbUserByEmailAsync(email);
            if (user == null)
            {
                return false;
            }
            var signInResult = await _SignInManager.PasswordSignInAsync(user, password, false, false);
            return signInResult.Succeeded;
        }

        public async Task<ValidationResult> ValidatePasswordAsync(string password)
        {
            ValidationResult validationResult = new ValidationResult();
            foreach (var validator in _UserManager.PasswordValidators)
            {
                var result = await validator.ValidateAsync(_UserManager, null, password);
                if (!result.Succeeded)
                {
                    validationResult.IsValid = false;
                    foreach (var err in result.Errors)
                    {
                        validationResult.Errors.Add(err.Description);
                    }
                }
            }
            return validationResult;
        }

        public async Task<string> GenerateAccountConfirmationTokenAsync(User user)
        {
            var dbUser = await GetDbUserByEmailAsync(user.Email);
            var confirmationToken = await _UserManager.GenerateEmailConfirmationTokenAsync(dbUser);

            return confirmationToken;
        }

        public async Task<bool> ConfirmationAccountAsync(User user, string confirmationToken)
        {
            var dbUser = await GetDbUserByEmailAsync(user.Email);
            var confirmationResult = await _UserManager.ConfirmEmailAsync(dbUser, confirmationToken);

            return confirmationResult.Succeeded;
        }
    }
}
