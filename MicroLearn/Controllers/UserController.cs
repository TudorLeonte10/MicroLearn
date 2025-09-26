using MicroLearn.Dtos.User;
using MicroLearn.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MicroLearn.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponse>> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            try
            {
                var resp = await _userService.RegisterAsync(registerRequestDto);
                return Ok(resp);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            try
            {
                var resp = await _userService.LoginAsync(loginRequestDto);
                return Ok(resp);
            }
            catch (ArgumentException ex)
            {
                // lipsesc câmpuri
                return BadRequest(new { error = ex.Message });
            }
            catch (UnauthorizedAccessException ex)
            {
                // user inexistent sau parolă greșită
                return Unauthorized(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                // fallback
                return StatusCode(500, new { error = ex.Message });
            }
        }


        [HttpGet("me")]
        [Authorize]
        public IActionResult Me()
        {
            var username = User.FindFirst("username")?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new { username, email, role });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
    }
}
