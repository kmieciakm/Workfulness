﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Contracts;

namespace WorkfulnessAPI.Services
{
    class SongsService : ISongsService
    {
        public string _BaseUrl { get; set; }

        public SongsService(string baseUrl)
        {
            // TODO: Create settings service and get baseUrl from service
            _BaseUrl = baseUrl;
        }

        public IEnumerable<string> GetAllSongsUrl()
        {
            // TODO: Retrive data from database
            return new List<string>()
            {
                $"{_BaseUrl}Crowander - Heavy Waves.mp3",
                $"{_BaseUrl}Derek Clegg - Blathering On.mp3"
            };
        }
    }
}