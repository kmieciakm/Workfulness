using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Models;
using WorkfulnessAPI.Services.Models.Config;
using WorkfulnessAPI.Services.Ports.Infrastructure;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services
{
    public class SongService : ISongService
    {
        private ISongsRegistry _SongsRegistry { get; }
        public SongsConfig _SongsConfig { get; set; }

        public SongService(ISongsRegistry songsRegistry, IOptions<SongsConfig> songsConfig)
        {
            _SongsRegistry = songsRegistry;
            _SongsConfig = songsConfig.Value;
        }

        public Song GetSongById(int id)
        {
            return _SongsRegistry.Get(id);
        }

        public byte[] GetSongBytes(int songId)
        {
            var song = _SongsRegistry.Get(songId);
            var filePath = $"{_SongsConfig.SongsFolder}{song?.FileName}";
            if (File.Exists(filePath))
            {
                var songBytes = File.ReadAllBytes(filePath);
                return songBytes;
            }
            return null;
        }
    }
}
