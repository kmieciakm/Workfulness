using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Contracts;

namespace WorkfulnessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ILogger<SongsController> _logger;
        private ISongsService _SongService { get; set; }

        public SongsController(ILogger<SongsController> logger, ISongsService songsService)
        {
            _logger = logger;
            _SongService = songsService;
        }

        // TODO: Add description for swagger
        [HttpGet]
        public IEnumerable<string> GetAllSongLinks()
        {
            return _SongService.GetAllSongsUrl();
        }
    }
}
