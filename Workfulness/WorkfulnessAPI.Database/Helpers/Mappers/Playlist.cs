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
                if (dbPlaylist == null) return null;
                return new DomainModels.Playlist(
                        dbPlaylist.Id,
                        dbPlaylist.Title,
                        dbPlaylist.CoverUrl,
                        dbPlaylist.Category?.Name,
                        Song.ToSong(dbPlaylist.Songs),
                        dbPlaylist.IsPublic
                    );
            }

            public static IEnumerable<DomainModels.Playlist> ToPlaylist(IEnumerable<DbPlaylist> dbPlaylists)
            {
                if (dbPlaylists == null) return null;
                return dbPlaylists.Select(dbPlaylist => ToPlaylist(dbPlaylist));
            }

            public static DbPlaylist ToDbPlaylist(DomainModels.Playlist playlist)
            {
                if (playlist == null) return null;
                return new DbPlaylist
                {
                    Id = playlist.Id,
                    Title = playlist.Title,
                    CoverUrl = playlist.CoverUrl,
                    Songs = Song.ToDbSong(playlist.Songs),
                    Category = new DbPlaylistCategory() {
                        Id = null,
                        Name = playlist.Category
                    },
                    CategoryId = null,
                    IsPublic = playlist.IsPublic
                };
            }
        }
    }
}
