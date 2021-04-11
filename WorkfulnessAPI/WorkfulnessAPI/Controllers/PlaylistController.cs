using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using WorkfulnessAPI.DTO;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private readonly ILogger<PlaylistController> _logger;
        private IPlaylistService _PlaylistService { get; set; }

        public PlaylistController(ILogger<PlaylistController> logger, IPlaylistService songsService)
        {
            _logger = logger;
            _PlaylistService = songsService;
        }

        /// <summary>
        /// Returns all playlists.
        /// </summary>
        /// <response code="200">Returns list of playlists.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PlaylistDTO>> GetPlaylists()
        {
            List<PlaylistDTO> playlists = new List<PlaylistDTO>();
            foreach(var playlist in _PlaylistService.GetPlaylists())
            {
                playlists.Add(new PlaylistDTO(playlist));
            }
            return playlists;
        }

        /// <summary>
        /// Returns playlist of given id.
        /// </summary>
        /// <param name="id">Id of a playlist</param>
        /// <response code="200">Return requested playlist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PlaylistDTO> GetPlaylist(int id)
        {
            var playlist = _PlaylistService.GetPlaylistById(id);
            return new PlaylistDTO(playlist);
        }
    }
}
