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
            Playlist playlist = new Playlist();
            playlist.CoverUrl = "https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260";
            playlist.Songs = new List<Song>() 
            {
                new Song 
                {
                    Title = "Blathering On",
                    Author = "Derek Clegg",
                    SongUrl = "./songs/Derek Clegg - Blathering On.mp3"
                },
                new Song 
                {
                    Title = "Heavy Waves",
                    Author = "Crowander",
                    SongUrl = "./songs/Crowander - Heavy Waves.mp3"
                }
            };
            return playlist;
        }
    }
}
