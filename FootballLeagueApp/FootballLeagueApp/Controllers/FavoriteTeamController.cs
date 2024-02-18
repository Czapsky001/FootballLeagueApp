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
        private readonly IFavoriteTeamService _favoriteTeamService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FavoriteTeamController(IFavoriteTeamService favoriteTeamService, UserManager<ApplicationUser> userManager)
        {
            _favoriteTeamService = favoriteTeamService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("add")]
        public async Task<ActionResult<bool>> AddToFavorite(Guid teamId, string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                await _favoriteTeamService.AddTeamToFavorite(user.Id, teamId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("remove")]
        public async Task<ActionResult<bool>> RemoveFromFavorite(Guid teamId, string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                await _favoriteTeamService.RemoveTeamFromFavorite(user.Id, teamId);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
