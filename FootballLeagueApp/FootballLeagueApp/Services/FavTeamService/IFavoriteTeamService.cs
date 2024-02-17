namespace FootballLeagueApp.Services.FavTeamService
{
    public interface IFavoriteTeamService
    {
        Task AddTeamToFavorite(string userId, Guid teamId);
    }
}
