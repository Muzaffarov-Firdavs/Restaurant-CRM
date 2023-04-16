using AutoMapper;
using Restaurant.Domain.Entities;
using Restaurant.Service.DTOs.Users;

namespace Restaurant.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User 
            CreateMap<User, UserForCreationDto>().ReverseMap();
            CreateMap<User, UserForResultDto>().ReverseMap();
            CreateMap<User, UserForUpdateDto>().ReverseMap();
            CreateMap<UserForCreationDto, UserForUpdateDto>().ReverseMap();



        }
    }
}
