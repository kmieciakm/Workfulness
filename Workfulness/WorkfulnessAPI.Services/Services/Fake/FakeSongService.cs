using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services.Fake
{
    public class FakeSongService : ISongService
    {
        public string _BaseSongsUrl { get; set; }
        public string _SongsDirectory { get; set; }
        
        public FakeSongService(string baseSongsUrl, string songsDirectory)
        {
            _BaseSongsUrl = baseSongsUrl;
            _SongsDirectory = songsDirectory;
        }

        public Song GetSongById(int id)
        {
            return new Song(
                id,
                "Blathering On",
                "Derek Clegg",
                "Derek Clegg - Blathering On.mp3"
            );
        }

        public byte[] GetSongBytes(int songId)
        {
            var filePath = $"{_SongsDirectory}Derek Clegg - Blathering On.mp3";
            var songBytes = System.IO.File.ReadAllBytes(filePath);
            return songBytes;
        }
    }
}
