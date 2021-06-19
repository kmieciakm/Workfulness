using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkfulnessAPI.DTO;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ILogger<ToDoController> _Logger { get; }
        private IAuthenticationService _AuthenticationService { get; }
        private ITodoListService _ToDoService { get; }

        public ToDoController(ILogger<ToDoController> logger, IAuthenticationService authenticationService, ITodoListService todoListService)
        {
            _Logger = logger;
            _AuthenticationService = authenticationService;
            _ToDoService = todoListService;
        }

        /// <summary>
        /// Returns todo lists of logged in user.
        /// </summary>
        /// <response code="200">Return lists.</response>
        [Authorize]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ToDoDTO>>> GetToDos()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                var toDos = _ToDoService.GetListsOfUser(user.Guid);
                var toDosDTO = toDos.Select(toDo => new ToDoDTO(toDo));
                return Ok(toDosDTO);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
