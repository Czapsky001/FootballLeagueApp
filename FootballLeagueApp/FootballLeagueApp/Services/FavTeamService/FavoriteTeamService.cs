using System;
using System.Threading.Tasks;
using FootballLeagueApp.DatabaseConnector;
using FootballLeagueApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.Services.FavTeamService
{
    public class FavoriteTeamService : IFavoriteTeamService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<FavoriteTeamService> _logger;

        public FavoriteTeamService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<FavoriteTeamService> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<Team> AddTeamToFavorite(string userId, Guid teamId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var team = await _context.Teams.FindAsync(teamId);

                user.FavoriteTeams.Add(team);
                team.Fans.Add(user);
                await _context.SaveChangesAsync();
                return team;

            }catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw;
            }

        }

    }
}
