using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Models;

namespace WorkfulnessAPI.Database.Seed
{
    public class DatabaseSeed
    {
        private DatabaseContext _Database { get; }

        public DatabaseSeed(DatabaseContext database)
        {
            _Database = database;
        }

        public void Seed()
        {
            ClearTables();
            ResetIdentityColumns();
            SeedCategories();
            SeedSongs();
            SeedPlaylists();

            _Database.SaveChanges();
            _Database.ChangeTracker.Clear();
        }

        private void ClearTables()
        {
            ClearSet<DbSong>();
            ClearSet<DbPlaylist>();
            ClearSet<DbPlaylistCategory>();
            _Database.SaveChanges();
        }

        private void SeedSongs()
        {
            var songs = new List<DbSong>()
            {
                new DbSong() {
                    Title = "Blathering On",
                    Author = "Derek Clegg",
                    FileName = "Derek Clegg - Blathering On.mp3"
                }
            };
            _Database.Songs.AddRange(songs);
            _Database.SaveChanges();
        }

        private void SeedCategories()
        {
            var categories = new List<DbPlaylistCategory>()
            {
                new DbPlaylistCategory() { Name = "Folk" },
                new DbPlaylistCategory() { Name = "Rock" },
                new DbPlaylistCategory() { Name = "Blues" }
            };
            _Database.PlaylistsCategories.AddRange(categories);
            _Database.SaveChanges();
        }

        private void SeedPlaylists()
        {
            var blatheringOn = _Database.Songs.FirstOrDefault(song => song.Title == "Blathering On");
            var playlists = new List<DbPlaylist>()
            {
                new DbPlaylist() {
                    CoverUrl = "https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    Title = "Calm Lake",
                    CategoryId = _Database.PlaylistsCategories.FirstOrDefault(cat => cat.Name == "Folk").Id,
                    Songs = new List<DbSong>()
                    {
                        blatheringOn
                    }
                }
            };
            _Database.Playlists.AddRange(playlists);
        }

        private void ClearSet<T>() where T : class
        {
            var dbSet = _Database.Set<T>();
            foreach (var entity in dbSet)
            {
                dbSet.Remove(entity);
            }
        }

        private void ResetIdentityColumns()
        {
            _Database.Database.ExecuteSqlRaw("DBCC CHECKIDENT ([Songs], RESEED, 0)");
            _Database.Database.ExecuteSqlRaw("DBCC CHECKIDENT ([Playlists], RESEED, 0)");
            _Database.Database.ExecuteSqlRaw("DBCC CHECKIDENT ([PlaylistsCategories], RESEED, 0)");
        }
    }
}
