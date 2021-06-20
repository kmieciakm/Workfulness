using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Helpers.Mappers;
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
        public IEnumerable<DbPlaylist> PrivatePlaylists { get; set; } = new List<DbPlaylist>();

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
            PrivatePlaylists = user.UsersPlaylists.Select(p => Mapper.Playlist.ToDbPlaylist(p)).ToList();
        }

        public DbUser() { }

        public User ToDomainUser()
        {
            return new User(
                Guid.Parse(Id),
                FirstName,
                LastName,
                Email,
                PrivatePlaylists.Select(p => Mapper.Playlist.ToPlaylist(p)).ToList(),
                EmailConfirmed
            );
        }
    }
}
