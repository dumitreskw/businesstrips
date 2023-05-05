using AutoMapper;
using BusinessTrips.Business.DTOs;
using BusinessTrips.Models;

namespace BusinessTrips.Business.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterDTO, User>()
        .ForMember(
                dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email.Split('@', StringSplitOptions.None)[0])
            );
        CreateMap<User, RegisterDTO>();
    }

}
