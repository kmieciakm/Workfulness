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
using WorkfulnessAPI.Models.Requests;
using WorkfulnessAPI.Services.Exceptions;
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
        /// <response code="409">Occures when cannot access user.</response>
        [Authorize]
        [HttpGet("")]
        [ActionName("GetToDos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
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
                return Conflict();
            }
        }

        /// <summary>
        /// Create new ToDo list for the logged in user.
        /// </summary>
        /// <response code="200">Return a new list.</response>
        /// <response code="404">Occures when given list does not exists.</response>
        /// <response code="409">Occures when cannot access user.</response>
        /// <response code="500">Unexpected error.</response>
        [Authorize]
        [HttpPost("{listname}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreateToDoList(string listname)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                try
                {
                    var toDoList = _ToDoService.CreateNewList(user.Guid, listname);
                    var toDosDTO = new ToDoDTO(toDoList);
                    return CreatedAtAction("GetToDos", toDosDTO);
                }
                catch (ToDoException toDoEx)
                    when (toDoEx.Cause == ExceptionCause.IncorrectInputData)
                {
                    _Logger.LogInformation(toDoEx, $"Cannot craete a new list.");
                    return BadRequest(new { toDoEx.Message, toDoEx.Details });
                }
                catch (ToDoException toDoEx)
                   when (toDoEx.Cause == ExceptionCause.Unknown)
                {
                    _Logger.LogError(toDoEx, $"Cannot craete a new list.");
                    throw;
                }
            }
            else
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Deletes given list of the logged in user.
        /// </summary>
        /// <response code="204">List has been deleted.</response>
        /// <response code="404">Occures when given list does not exists.</response>
        /// <response code="409">Occures when cannot access user.</response>
        /// <response code="500">Unexpected error.</response>
        [Authorize]
        [HttpDelete("{listname}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteToDoList(string listname)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                try
                {
                    _ToDoService.DeleteList(user.Guid, listname);
                    return NoContent();
                }
                catch (ToDoException toDoEx)
                    when (toDoEx.Cause == ExceptionCause.IncorrectInputData)
                {
                    _Logger.LogInformation(toDoEx, $"List cannot be deleted.");
                    return BadRequest(new { toDoEx.Message, toDoEx.Details });
                }
                catch (ToDoException toDoEx)
                   when (toDoEx.Cause == ExceptionCause.Unknown)
                {
                    _Logger.LogError(toDoEx, $"List cannot be deleted.");
                    throw;
                }
            }
            else
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Edit tasks for the given list.
        /// </summary>
        /// <response code="200">Returns edited list.</response>
        /// <response code="404">Occures when given list does not exists.</response>
        /// <response code="409">Occures when cannot access user.</response>
        /// <response code="500">Unexpected error.</response>
        [Authorize]
        [HttpPatch("{listname}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> EditTasks(string listname, [FromBody] IEnumerable<TaskItemDTO> tasksToEdit)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                try
                {
                    var tasks = tasksToEdit.Select(task => task.ToTaskItem());
                    var toDoList = _ToDoService.EditTasks(user.Guid, listname, tasks);
                    var toDosDTO = new ToDoDTO(toDoList);
                    return Ok(toDosDTO);
                }
                catch (ToDoException toDoEx)
                    when (toDoEx.Cause == ExceptionCause.IncorrectInputData)
                {
                    _Logger.LogInformation(toDoEx, $"Cannot edit tasks from '{listname}' list.");
                    return BadRequest(new { toDoEx.Message, toDoEx.Details });
                }
                catch (ToDoException toDoEx)
                   when (toDoEx.Cause == ExceptionCause.Unknown)
                {
                    _Logger.LogError(toDoEx, $"Cannot edit tasks from '{listname}' list.");
                    throw;
                }
            }
            else
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Add tasks for the given list.
        /// </summary>
        /// <response code="200">Return the list.</response>
        /// <response code="404">Occures when given list does not exists.</response>
        /// <response code="409">Occures when cannot access user.</response>
        /// <response code="500">Unexpected error.</response>
        [Authorize]
        [HttpPost("{listname}/task")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddTaskToList(string listname, [FromBody] IEnumerable<TaskCreateRequest> tasksToCreate)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                try
                {
                    var tasks = tasksToCreate.Select(task => task.ToTaskItem());
                    var toDoList = _ToDoService.AddTasksToList(user.Guid, listname, tasks);
                    var toDosDTO = new ToDoDTO(toDoList);
                    return CreatedAtAction("GetToDos", toDosDTO);
                }
                catch (ToDoException toDoEx)
                    when (toDoEx.Cause == ExceptionCause.IncorrectInputData)
                {
                    _Logger.LogInformation(toDoEx, $"Cannot add task to list.");
                    return BadRequest(new { toDoEx.Message, toDoEx.Details });
                }
                catch (ToDoException toDoEx)
                   when (toDoEx.Cause == ExceptionCause.Unknown)
                {
                    _Logger.LogError(toDoEx, $"Cannot add task to list.");
                    throw;
                }
            }
            else
            {
                return Conflict();
            }
        }

        /// <summary>
        /// Delete task for the given list.
        /// </summary>
        /// <response code="204">Task has been deleted.</response>
        /// <response code="404">Occures when given list does not exists.</response>
        /// <response code="409">Occures when cannot access user.</response>
        /// <response code="500">Unexpected error.</response>
        [Authorize]
        [HttpPost("{listname}/task/{taskId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteTaskFromList(string listname, int taskId)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user != null)
            {
                try
                {
                    _ToDoService.DeleteTask(user.Guid, listname, taskId);
                    return NoContent();
                }
                catch (ToDoException toDoEx)
                    when (toDoEx.Cause == ExceptionCause.IncorrectInputData)
                {
                    _Logger.LogInformation(toDoEx, $"Cannot delete task from the list.");
                    return BadRequest(new { toDoEx.Message, toDoEx.Details });
                }
                catch (ToDoException toDoEx)
                   when (toDoEx.Cause == ExceptionCause.Unknown)
                {
                    _Logger.LogError(toDoEx, $"Cannot delete task from the list.");
                    throw;
                }
            }
            else
            {
                return Conflict();
            }
        }
    }
}
