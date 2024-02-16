using FootballLeagueApp.Models;
using FootballLeagueApp.Repositories;

namespace FootballLeagueApp.Services.TeamsService;

public class TeamService : ITeamService
{
    private readonly ILogger<TeamService> _logger;
    private readonly ITeamRepository teamRepository;

    public TeamService(ILogger<TeamService> logger, ITeamRepository teamRepository)
    {
        _logger = logger;
        this.teamRepository = teamRepository;
    }

    public async Task<Team> CreateTeamAsync(Team team)
    {
        var existingTeam = teamRepository.GetTeamByNameAsync(team.Name).Result;

        if (existingTeam != null)
        {
            _logger.LogInformation($"Team {team.Name} already exists. ");
            //return await existingTeam;
            throw new Exception();
        }
        var newTeam = new Team
        {
            Name = team.Name,
            Points = team.Points,
            PlayedMatches = team.PlayedMatches,
            Wins = team.Wins,
            Loses = team.Loses,
            Draws = team.Draws,
            Goals = team.Goals
        };
        await teamRepository.AddTeamAsync(newTeam);
        return newTeam;
    }

    public async Task<IEnumerable<Team>> GetAllTeamsAsync()
    {
        return await teamRepository.GetTeamsAsync();
    }

    public async Task<Team> GetTeamByNameAsync(string name)
    {
        return await teamRepository.GetTeamByNameAsync(name);

    }
}
