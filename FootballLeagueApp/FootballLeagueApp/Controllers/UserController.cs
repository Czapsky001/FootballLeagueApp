using FootballLeagueApp.Dto;
using FootballLeagueApp.Services.UsersService;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet("/api/user")]
        public async Task<ActionResult<UserDto>> GetByNameAsync([FromQuery] string name)
        {
            try
            {
                var user = await _userService.GetByNameAsync(name);
                if (user == null)
                {
                    return NotFound("Not found user");
                }
                return Ok(user);
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
