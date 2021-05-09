using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Context;
using WorkfulnessAPI.Database.Helpers.Mappers;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Infrastructure;

namespace WorkfulnessAPI.Database.Repositories
{
    public class SongsRegistry : ISongsRegistry
    {
        public DatabaseContext _Database { get; }
        public SongsRegistry(DatabaseContext database)
        {
            _Database = database;
        }

        public void Add(Song song)
        {
            var dbSong = Mapper.Song.ToDbSong(song);
            _Database.Songs.Add(dbSong);
        }

        public Song Get(int id)
        {
            var dbSong = _Database.Songs
                .FirstOrDefault(song => song.Id == id);
            return Mapper.Song.ToSong(dbSong);
        }

        public void Remove(int id)
        {
            var song = Mapper.Song.ToDbSong(Get(id));
            if (song == null)
            {
                _Database.Songs.Remove(song);
            }
        }

        public void Update(Song song)
        {
            var dbSong = Mapper.Song.ToDbSong(song);
            _Database.Songs.Update(dbSong);
        }
    }
}
