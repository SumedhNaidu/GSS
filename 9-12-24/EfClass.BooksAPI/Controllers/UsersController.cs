using EfClass.Models.DTOs;
using EfClass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfClass.BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var res = _userService.GetUsers();
            return Ok(res);
        }
        [HttpGet("Id")]
        public IActionResult Get(int id)
        {
            var result = _userService.GetUser(id);
            return Ok(result);
        }
        [HttpGet("email")]
        public IActionResult GetEmail(string email)
        {
            var result = _userService.GetUserByEmail(email);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post(UserDto userDto)
        {
            var result = _userService.SaveNewUser(userDto);
            return Ok(result);
        }
    }
}
