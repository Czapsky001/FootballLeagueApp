using Microsoft.AspNetCore.Identity;

namespace FootballLeagueApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Team> FavoriteTeams { get; set; } = new List<Team>();
    }
}
