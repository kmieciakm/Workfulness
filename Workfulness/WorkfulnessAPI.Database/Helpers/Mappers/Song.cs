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
            public static IEnumerable<DomainModels.Song> ToSong(ICollection<DbSong> dbSongs)
            {
                return dbSongs.Select(dbSong =>
                        new DomainModels.Song(
                            dbSong.Id,
                            dbSong.Title,
                            dbSong.Author,
                            dbSong.FileName
                        )
                    );
            }
        }
    }
}
