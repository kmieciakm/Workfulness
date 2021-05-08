using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Database.Models;
using DomainModels = WorkfulnessAPI.Services.Models;

namespace WorkfulnessAPI.Database.Helpers.Mappers
{
    public static partial class Mapper
    {
        public static class Song
        {
            public static IEnumerable<DomainModels.Song> ToSong(IEnumerable<DbSong> dbSongs)
            {
                if (dbSongs == null) return null;
                return dbSongs.Select(dbSong =>
                        new DomainModels.Song(
                            dbSong.Id,
                            dbSong.Title,
                            dbSong.Author,
                            dbSong.FileName
                        )
                    );
            }

            public static IEnumerable<DbSong> ToSong(IEnumerable<DomainModels.Song> songs)
            {
                if (songs == null) return null;
                return songs.Select(song =>
                        new DbSong {
                            Id = song.Id,
                            Title = song.Title,
                            Author = song.Author,
                            FileName = song.FileName
                        }
                    );
            }
        }
    }
}
