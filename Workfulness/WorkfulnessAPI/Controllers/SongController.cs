using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private ILogger<SongController> _Logger { get; }
        private ISongService _SongService { get; }

        public SongController(ILogger<SongController> logger, ISongService songService) 
        {
            _Logger = logger;
            _SongService = songService;
        }

        /// <summary>
        /// Download song of given id.
        /// </summary>
        /// <param name="id">Id of a song</param>
        /// <response code="200">Requested songs bytes.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetSong(int id)
        {
            var song = _SongService.GetSongById(id);
            var songBytes = _SongService.GetSongBytes(id);

            return File(songBytes, "audio/mpeg", song.FileName, true);
        }
    }
}
