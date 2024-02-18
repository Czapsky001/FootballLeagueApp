using AutoMapper;
using FootballLeagueApp.DatabaseConnector;
using FootballLeagueApp.Dto;
using FootballLeagueApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FootballLeagueApp.Services.UsersService
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<UserDto> GetByNameAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return null;
            }
            var teamsWithUserAsFan = await _applicationDbContext.Teams
                .Where(t => t.Fans.Any(f => f.UserName == user.UserName))
                .ToListAsync();

            var userDto = _mapper.Map<UserDto>(user);
            userDto.favoriteTeams = teamsWithUserAsFan;
            return userDto;
        }
    }
}
