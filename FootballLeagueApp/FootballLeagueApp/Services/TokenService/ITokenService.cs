using Microsoft.AspNetCore.Identity;

namespace FootballLeagueApp.Services.TokenService;

public interface ITokenService
{
    public string CreateToken(IdentityUser user);
}
