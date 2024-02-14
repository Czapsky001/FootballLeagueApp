using FootballLeagueApp.Models;
using FootballLeagueApp.Repositories;
using FootballLeagueApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeagueApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {
        private ILogger<TeamsController> logger;
        private ITeamService teamService;

        public TeamsController(ILogger<TeamsController> logger, ITeamService teamService)
        {
            this.logger = logger;
            this.teamService = teamService;
        }

        [HttpGet(Name = "GetAllTeams")]
        public async Task<ActionResult<IEnumerable<Team>>> GetAllTeams() 
        {
            try
            {
                var teams = await teamService.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
;
        }
        [HttpPost(Name = "CreateTeam")]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            try
            {
                var newTeam = await teamService.CreateTeamAsync(team);
                return Ok(newTeam);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetByName", Name = "GetByName")]
        public async Task<ActionResult<Team>> GetByName(string name)
        {
            try
            {
                var selectedTeam = await teamService.GetTeamByNameAsync(name);
                if(selectedTeam == null)
                {
                    return NotFound($"Not found team {name}");
                }
                return Ok(selectedTeam);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }
}
