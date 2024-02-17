using System;

namespace FootballLeagueApp.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Points { get; set; }
        public int PlayedMatches { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Draws { get; set; }
        public int Goals { get; set; }
        public List<ApplicationUser> Fans { get; set; } = new List<ApplicationUser>();
    }
}
