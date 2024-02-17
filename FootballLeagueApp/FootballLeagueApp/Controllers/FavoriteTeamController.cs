using FootballLeagueApp.Models;
using FootballLeagueApp.Services.FavTeamService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteTeamController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FavoriteTeamService _favoriteTeamService;

        public FavoriteTeamController(UserManager<ApplicationUser> userManager, FavoriteTeamService favoriteTeamService)
        {
            _userManager = userManager;
            _favoriteTeamService = favoriteTeamService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddToFavorite(Guid teamId)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            await _favoriteTeamService.AddTeamToFavorite(user.Id, teamId);

            return Ok();
        }
    }
}
