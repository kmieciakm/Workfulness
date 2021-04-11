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
        private static Playlist samplePlaylist { get; set; } = new Playlist()
        {
            CoverUrl = "https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
            Title = "This is Sample Playlist Title",
            Songs = new List<Song>()
                {
                    new Song
                    {
                        Id = 0,
                        Title = "Blathering On",
                        Author = "Derek Clegg",
                        Url = "./songs/Derek Clegg - Blathering On.mp3"
                    },
                    new Song
                    {
                        Id = 1,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 2,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 3,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 4,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 5,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 6,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        Id = 7,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        Url = "./songs/Crowander - Heavy Waves.mp3"
                    }
                }
        };

        public async Task<Playlist> GetPlaylistAsync(int id)
        {
            await Task.Delay(100);
            return samplePlaylist;
        }
    }
}
