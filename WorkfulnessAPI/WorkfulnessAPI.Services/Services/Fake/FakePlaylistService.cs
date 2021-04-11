using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services.Fake
{
    public class FakePlaylistService : IPlaylistService
    {
        public string _BaseSongsUrl { get; set; }
        public string _SongsDirectory { get; set; }

        public FakePlaylistService(string baseSongsUrl, string songsDirectory)
        {
            _BaseSongsUrl = baseSongsUrl;
            _SongsDirectory = songsDirectory;
        }

        public IEnumerable<Playlist> GetPlaylists()
        {
            return new List<Playlist>() {
                new Playlist(
                    "Calm lake",
                    @"https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    new List<Song>() {
                        new Song(0, "Blathering On", "Derek Clegg", $"{_BaseSongsUrl}/{0}", "Derek Clegg - Blathering On.mp3", $"{_SongsDirectory}Derek Clegg - Blathering On.mp3"),
                        new Song(1, "Heavy Waves", "Crowander", $"{_BaseSongsUrl}/{1}", "Heavy Waves - Crowander.mp3", $"{_SongsDirectory}Heavy Waves - Crowander.mp3")
                    }
                ),
                new Playlist(
                    "Calm lake 2",
                    @"https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                    new List<Song>() {
                        new Song(0, "Blathering On", "Derek Clegg", $"{_BaseSongsUrl}/{0}", "Derek Clegg - Blathering On.mp3", $"{_SongsDirectory}Derek Clegg - Blathering On.mp3"),
                        new Song(1, "Heavy Waves", "Crowander", $"{_BaseSongsUrl}/{1}", "Heavy Waves - Crowander.mp3", $"{_SongsDirectory}Heavy Waves - Crowander.mp3"),
                        new Song(0, "Blathering On", "Derek Clegg", $"{_BaseSongsUrl}/{0}", "Derek Clegg - Blathering On.mp3",$"{_SongsDirectory}Derek Clegg - Blathering On.mp3"),
                        new Song(1, "Heavy Waves", "Crowander", $"{_BaseSongsUrl}/{1}", "Heavy Waves - Crowander.mp3", $"{_SongsDirectory}Heavy Waves - Crowander.mp3")
                    }
                )
            };
        }

        public Playlist GetPlaylistById(int id)
        {
            return new Playlist(
                "Calm lake",
                @"https://images.pexels.com/photos/747964/pexels-photo-747964.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260",
                new List<Song>() {
                    new Song(0, "Blathering On", "Derek Clegg", $"{_BaseSongsUrl}0", "Derek Clegg - Blathering On.mp3", $"{_SongsDirectory}Derek Clegg - Blathering On.mp3"),
                    new Song(1, "Heavy Waves", "Crowander", $"{_BaseSongsUrl}1", "Heavy Waves - Crowander.mp3", $"{_SongsDirectory}Heavy Waves - Crowander.mp3"),
                }
            );
        }
    }
}
