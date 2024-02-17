using System;
using System.Threading.Tasks;
using FootballLeagueApp.DatabaseConnector;
using FootballLeagueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.Services.FavTeamService
{
    public class FavoriteTeamService : IFavoriteTeamService
    {
        private readonly UserContext _context;

        public FavoriteTeamService(UserContext context)
        {
            _context = context;
        }

        public async Task AddTeamToFavorite(string userId, Guid teamId)
        {
            throw new NotImplementedException();
        }
    }
}
