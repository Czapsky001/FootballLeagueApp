using FootballLeagueApp.Models;

namespace FootballLeagueApp.Dto
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public List<Team> favoriteTeams { get; set; }

    }
}
