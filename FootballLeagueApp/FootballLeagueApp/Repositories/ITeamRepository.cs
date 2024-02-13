using FootballLeagueApp.Models;

namespace FootballLeagueApp.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetTeams();

        Task<Team> GetTeamByName(string name);

        Task<bool> AddTeamAsync (Team team);

        Task<bool> DeleteTeamAsync(Team team);
    }
}
