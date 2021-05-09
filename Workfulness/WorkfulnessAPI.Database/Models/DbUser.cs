using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Database.Models
{
    public class DbUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public DbUser(string firstname, string lastname, string email) : base()
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            UserName = Email;
        }

        public DbUser(User user) : base()
        {
            FirstName = user.Firstname;
            LastName = user.Lastname;
            Email = user.Email;
            EmailConfirmed = user.AccountConfirmed;
            UserName = Email;
        }

        public DbUser() { }

        public User ToDomainUser()
        {
            return new User(
                Guid.Parse(Id),
                FirstName,
                LastName,
                Email,
                EmailConfirmed
            );
        }
    }
}
