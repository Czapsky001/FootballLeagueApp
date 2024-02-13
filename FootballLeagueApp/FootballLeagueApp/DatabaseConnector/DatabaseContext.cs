using FootballLeagueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.DatabaseConnector
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
