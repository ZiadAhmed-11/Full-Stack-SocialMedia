using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Data.Data.DTO;
using SocialMedia.Data.Models;
using SocialMedia.Services.ServiceContracts;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> AddUser(RegisterDTO registerUser)
        {
            if(ModelState.IsValid==false)
            {
                string errorMessages= string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessages);
            }

            var user = _userService.IsEmailIsAlreadyExist(registerUser.Email);
            if (user == false)
            {
                _logger.LogInformation("AddUser Action Method of UserController");
                _logger.LogDebug($"Added User: {registerUser.FirstName} {registerUser.LastName}");
                await _userService.SendEmail(registerUser.Email, "You have Registered in our social media palatform", "Welcome To Our Social Media Sign ♥.");
                await _userService.AddAsync(registerUser);
                

                return Ok(registerUser);
            }
            return BadRequest("Email Address is already exists.");
          
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> PostLogin(LoginDTO loginDTO)
        {
            if(ModelState.IsValid==false)
            {
                var errorMessages = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Problem(errorMessages);
            }
            var result = await _userService.Login(loginDTO);
            return result;
        }

        [HttpPost("logout")]
        public async Task<ActionResult> GetLogout()
        {
            await _userService.Logout();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = _userService.GetAllUsersAsync().ToString();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetUserByUserId(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }



        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var result = await _userService.UpdateUser(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<User>>> SearchUser([FromQuery] string keyword)
        {
            if(string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Keyword cannot be empty.");

            }
            var users = await _userService.SearchUser(keyword);
            if(users is null ||users.Count==0)
            {
                return NotFound("No users found matching the provided keyword.");
            }
            return Ok(users);
        }
    }
}
