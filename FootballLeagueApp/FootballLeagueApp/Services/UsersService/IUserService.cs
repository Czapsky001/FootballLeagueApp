using FootballLeagueApp.Dto;

namespace FootballLeagueApp.Services.UsersService
{
    public interface IUserService
    {
        Task<UserDto> GetByNameAsync(string name); 
    }
}
