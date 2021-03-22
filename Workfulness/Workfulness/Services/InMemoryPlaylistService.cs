using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workfulness.Models;
using Workfulness.Services.Contracts;

namespace Workfulness.Services
{
    internal class InMemoryPlaylistService : IPlaylistService
    {
        public Playlist GetPlaylist()
        {
            return new Playlist()
            {
                CoverUrl = "https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                Title = "This is Sample Playlist Title",
                Songs = new List<Song>()
                {
                    new Song
                    {
                        SongId = 0,
                        Title = "Blathering On",
                        Author = "Derek Clegg",
                        SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                    },
                    new Song
                    {
                        SongId = 1,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 2,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 3,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 4,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    }
                }
            };
        }
    }
}
