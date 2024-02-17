using FootballLeagueApp.DatabaseConnector;
using FootballLeagueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly DatabaseContext ctx;
    private readonly ILogger<TeamRepository> logger;

    public TeamRepository(DatabaseContext ctx, ILogger<TeamRepository> logger)
    {
        this.ctx = ctx;
        this.logger = logger;
    }



    public async Task<Team> GetTeamByNameAsync(string name)
    {
        try
        {
            return await ctx.Team.FirstOrDefaultAsync(e => e.Name == name);
        }
        catch(Exception ex)
        {
            logger.LogError(ex.Message);
            return new Team();
        }

    }

    public async Task<IEnumerable<Team>> GetTeamsAsync()
    {
        try
        {
            return await ctx.Team.OrderBy(e => e.Points).ToListAsync();

        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            return new List<Team>();
        }
    }

    public async Task<bool> AddTeamAsync(Team team)
    {
        try
        {
            await ctx.Team.AddAsync(team);
            await ctx.SaveChangesAsync();
            return true;
        }catch(Exception ex)
        {
            logger.LogError(ex.Message, ex);
            return false;
        }


    }


    public async Task<bool> DeleteTeamAsync(Team team)
    {
        try
        {
            ctx.Team.Remove(team);
            await ctx.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            return false;
        }
    }
}
