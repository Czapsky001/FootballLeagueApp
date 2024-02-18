using AutoMapper;
using FootballLeagueApp.Dto;
using FootballLeagueApp.Models;
namespace FootballLeagueApp.AutoMapperProfiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ApplicationUser, UserDto>();
        CreateMap<UserDto, ApplicationUser>();
    }
}
