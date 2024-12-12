using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Security.Claims;
using UsersTask.Service;
using UsersTask.ViewModels;

namespace UsersTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDto loginDto) 
        {
            try
            {
                var x = HttpContext.User.FindFirstValue(ClaimTypes.Role);
                var xd = HttpContext.User.FindFirstValue(ClaimTypes.Name);

                var token = _userService.Login(loginDto);
                return Ok(new {Token = token });
                //return Ok(new { Token = token, role = ClaimTypes.Role });
            } 
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new {Message = "Invalid credentials"});
            }
        }

        [HttpPost("create")]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateUser([FromBody] CreateUserDto userDto)
        {
            try
            {
                ResponseUserDto user = _userService.Add(userDto);
                return Ok(user);
                //return CreatedAtAction(nameof(CreateUser),
                //    new { username = user.Username },
                //    user);
                //return Ok();


            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpDelete("{username}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteUser(string username)
        {
            try
            {
                _userService.Delete(username);
                return Ok(new { Message = "User deleted successfully" });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { Message = "User not found" });
            }
        }
        [HttpGet("{username}")]
        [Authorize]
        public IActionResult GetUser(string username)
        {
            try
            {
                var user = _userService.GetUserByUsername(username);
                return Ok(user);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new {Message = "User not found"});
            }
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllUsers()
        {
            //List<ResponseUserDto> users = (List<ResponseUserDto>)_userService.GetAll();
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
