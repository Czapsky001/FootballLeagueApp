using FootballLeagueApp.Models;

namespace FootballLeagueApp.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetTeamsAsync();

        Task<Team> GetTeamByNameAsync(string name);

        Task<bool> AddTeamAsync (Team team);

        Task<bool> DeleteTeamAsync(Team team);
    }
}
