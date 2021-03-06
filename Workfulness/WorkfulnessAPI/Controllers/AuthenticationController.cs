using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkfulnessAPI.Helpers.Mappers;
using WorkfulnessAPI.Models.Requests;
using WorkfulnessAPI.Services.Exceptions;
using WorkfulnessAPI.Services.Ports.Presenters;

namespace WorkfulnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogger<AuthenticationController> _Logger { get; }
        private IAuthenticationService _AuthenticationService { get; }

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _Logger = logger;
            _AuthenticationService = authenticationService;
        }

        [Authorize]
        [ActionName("GetIdentity")]
        [HttpPost("identity")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetIdentity()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _AuthenticationService.GetIdentity(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> SignIn(SignInRequest request)
        {
            try
            {
                var signIn = Mapper.Request.ToSignIn(request);
                var token = await _AuthenticationService.SignInAsync(signIn);

                return token;
            }
            catch (AuthenticationException authEx)
               when (authEx.Cause == ExceptionCause.IncorrectInputData)
            {
                _Logger.LogInformation(authEx, $"User login failed.");
                return BadRequest(authEx.Message);
            }
            catch (AuthenticationException authEx)
               when (authEx.Cause == ExceptionCause.Unknown)
            {
                _Logger.LogError(authEx, $"User login failed unexpectedly.");
                return StatusCode(StatusCodes.Status500InternalServerError, authEx.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            try
            {
                var signUp = Mapper.Request.ToSignUp(request);
                var user = await _AuthenticationService.SignUpAsync(signUp);

                return CreatedAtAction("GetIdentity", user);
            }
            catch (RegistrationException registerEx)
                when (registerEx.Cause == ExceptionCause.IncorrectInputData)
            {
                _Logger.LogInformation(registerEx, $"Cannot register a new user.");
                return BadRequest(new { registerEx.Message, registerEx.Details });
            }
            catch (RegistrationException registerEx)
               when (registerEx.Cause == ExceptionCause.Unknown)
            {
                _Logger.LogError(registerEx, $"Cannot register a new user.");
                throw;
            }
        }
    }
}
