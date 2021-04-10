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
                PlaylistId = 0,
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
                    },
                    new Song
                    {
                        SongId = 5,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 6,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 7,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 8,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 9,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 10,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 11,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 12,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 13,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 14,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 15,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 16,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 17,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 18,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    },
                    new Song
                    {
                        SongId = 19,
                        Title = "Heavy Waves",
                        Author = "Crowander",
                        SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                    }
                }
            };
        }
        public List<Playlist> GetPlaylists()
        {
            return new List<Playlist>()
            {
                new Playlist()
                {
                    CoverUrl = "https://images.pexels.com/photos/2691882/pexels-photo-2691882.jpeg?auto=compress&cs=tinysrgb&h=750&w=1260",
                    Title = "This is Sample Title",
                    PlaylistId = 1,
                    Songs = new List<Song>()
                    {
                        new Song
                        {
                            SongId = 20,
                            Title = "Blathering On",
                            Author = "Derek Clegg",
                            SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                        },
                        new Song
                        {
                            SongId = 21,
                            Title = "Heavy Waves",
                            Author = "Crowander",
                            SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                        }
                    }
                },
                new Playlist()
                {
                    CoverUrl = "https://images.pexels.com/photos/1556797/pexels-photo-1556797.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    Title = "This is Sample Title",
                    PlaylistId = 2,
                    Songs = new List<Song>()
                    {
                        new Song
                        {
                            SongId = 22,
                            Title = "Blathering On",
                            Author = "Derek Clegg",
                            SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                        },
                        new Song
                        {
                            SongId = 23,
                            Title = "Heavy Waves",
                            Author = "Crowander",
                            SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                        }
                    }
                },
                 new Playlist()
                {
                    CoverUrl = "https://images.pexels.com/photos/7210517/pexels-photo-7210517.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    Title = "This is Title",
                    PlaylistId = 3,
                    Songs = new List<Song>()
                    {
                        new Song
                        {
                            SongId = 24,
                            Title = "Blathering On",
                            Author = "Derek Clegg",
                            SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                        },
                        new Song
                        {
                            SongId = 25,
                            Title = "Heavy Waves",
                            Author = "Crowander",
                            SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                        }
                    }
                },
                new Playlist()
                {
                    CoverUrl = "https://images.pexels.com/photos/1556797/pexels-photo-1556797.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    Title = "This is Sample Title",
                    PlaylistId = 3,
                    Songs = new List<Song>()
                    {
                        new Song
                        {
                            SongId = 26,
                            Title = "Blathering On",
                            Author = "Derek Clegg",
                            SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                        },
                        new Song
                        {
                            SongId = 27,
                            Title = "Heavy Waves",
                            Author = "Crowander",
                            SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                        }
                    }
                },
                 new Playlist()
                {
                    CoverUrl = "https://images.pexels.com/photos/7210517/pexels-photo-7210517.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500",
                    Title = "This is Title",
                    PlaylistId = 4,
                    Songs = new List<Song>()
                    {
                        new Song
                        {
                            SongId = 28,
                            Title = "Blathering On",
                            Author = "Derek Clegg",
                            SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                        },
                        new Song
                        {
                            SongId = 29,
                            Title = "Heavy Waves",
                            Author = "Crowander",
                            SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                        }
                    }
                }
            };
        }
    }
}
