using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Services.Services.Fake
{
    public class FakeSongsService : ISongsService
    {
        public string _BaseUrl { get; set; }

        public FakeSongsService(string baseSongsUrl)
        {
            _BaseUrl = baseSongsUrl;
        }

        public IEnumerable<string> GetAllSongsUrl()
        {
            return new List<string>()
            {
                $"{_BaseUrl}Crowander - Heavy Waves.mp3",
                $"{_BaseUrl}Derek Clegg - Blathering On.mp3"
            };
        }
    }
}
