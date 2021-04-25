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
        public static class Playlist
        {
            public static DomainModels.Playlist ToPlaylist(DbPlaylist dbPlaylist) {
                return new DomainModels.Playlist(
                        dbPlaylist.Id,
                        dbPlaylist.Title,
                        dbPlaylist.CoverUrl,
                        dbPlaylist.Category.Name,
                        Song.ToSong(dbPlaylist.Songs)
                    );
            }
        }
    }
}
