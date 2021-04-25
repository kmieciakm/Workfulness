using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Models;

namespace WorkfulnessAPI.Database.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DbSong> Songs { get; set; }
        public DbSet<DbPlaylistCategory> PlaylistsCategories { get; set; }
        public DbSet<DbPlaylist> Playlists { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> dbOptions) : base(dbOptions) { }
    }
}
