using FootballLeagueApp.Models;

namespace FootballLeagueApp.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByNameAsync(string name);
        Task<Team> CreateTeamAsync(Team team);
    }
}