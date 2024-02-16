using FootballLeagueApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.DatabaseConnector;

public class UserContext : IdentityUserContext<IdentityUser>
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
