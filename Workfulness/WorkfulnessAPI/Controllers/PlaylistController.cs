using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkfulnessAPI.DTO;
using WorkfulnessAPI.Services.Helpers;
using WorkfulnessAPI.Services.Models.Config;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : ControllerBase
    {
        private ILogger<PlaylistController> _Logger { get; }
        public string _BaseSongsUrl { get; }
        private IPlaylistService _PlaylistService { get; set; }
        private IAuthenticationService _AuthenticationService { get; set; }

        public PlaylistController(ILogger<PlaylistController> logger, IPlaylistService songsService,
            IOptions<SongsConfig> songsConfig, IAuthenticationService authenticationService)
        {
            _Logger = logger;
            _BaseSongsUrl = songsConfig.Value.BaseSongsUrl;
            _PlaylistService = songsService;
            _AuthenticationService = authenticationService;
        }

        /// <summary>
        /// Returns all playlists.
        /// </summary>
        /// <param name="playlistCategory">Category name to filter playlists.</param>
        /// <response code="200">Returns list of playlists.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<PlaylistDTO>> GetPlaylists([FromQuery] string playlistCategory)
        {
            if (!string.IsNullOrEmpty(playlistCategory))
            {
                var categories = _PlaylistService.GetAvailablePlaylistsCategories();
                if (!categories.Any(category => category.EqualsCaseInsensitive(playlistCategory)))
                {
                    return NotFound(new { category = playlistCategory });
                }

                return new OkObjectResult(GetPlaylistsByCategory(playlistCategory));
            }

            List<PlaylistDTO> playlists = new List<PlaylistDTO>();
            foreach (var playlist in _PlaylistService.GetPlaylists())
            {
                playlists.Add(new PlaylistDTO(playlist, _BaseSongsUrl));
            }
            return playlists;
        }

        private IEnumerable<PlaylistDTO> GetPlaylistsByCategory(string category)
        {
            List<PlaylistDTO> playlists = new List<PlaylistDTO>();
            foreach (var playlist in _PlaylistService.GetPlaylistsOfCategory(category))
            {
                playlists.Add(new PlaylistDTO(playlist, _BaseSongsUrl));
            }
            return playlists;
        }

        /// <summary>
        /// Returns playlist of given id.
        /// </summary>
        /// <param name="id">Id of a playlist.</param>
        /// <response code="200">Return requested playlist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PlaylistDTO> GetPlaylist(int id)
        {
            var playlist = _PlaylistService.GetPlaylistById(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return new PlaylistDTO(playlist, _BaseSongsUrl);
        }

        /// <summary>
        /// Returns available categories of playlists.
        /// </summary>
        /// <response code="200">Return categories.</response>
        [HttpGet("category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetPlaylistsCategories()
        {
            var categories = _PlaylistService.GetAvailablePlaylistsCategories();
            return new List<string>(categories);
        }

        [Authorize]
        [HttpGet("private")]
        public async Task<ActionResult<IEnumerable<PlaylistDTO>>> GetUserPrivatePlaylists()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                var playlists = _PlaylistService.GetPlaylistsOfUser(user.Guid);
                var playlistsDTO = playlists.Select(playlist => new PlaylistDTO(playlist, _BaseSongsUrl));
                return Ok(playlistsDTO);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
