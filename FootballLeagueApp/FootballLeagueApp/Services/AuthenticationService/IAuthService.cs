using FootballLeagueApp.Authentication;

namespace FootballLeagueApp.Services.AuthenticationService;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string userName, string password);
    Task<AuthResult> LoginAsync(string email, string password);
}
