using FootballLeagueApp.Models;

namespace FootballLeagueApp.Services.FavTeamService
{
    public interface IFavoriteTeamService
    {
        Task<Team> AddTeamToFavorite(string userId, Guid teamId);
        Task<bool> RemoveTeamFromFavorite(string userId, Guid teamId);
    }
}
