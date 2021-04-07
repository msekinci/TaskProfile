using AutoMapper;
using MSE.TaskProfile.Entities.Concrete;
using MSE.TestProfile.DTO.Concrete.UserDTOs;

namespace MSE.TaskProfile.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserCreateDTO, User>();
            CreateMap<User, UserCreateDTO>();

            CreateMap<UserUpdateDTO, User>();
            CreateMap<User, UserUpdateDTO>();

            CreateMap<UserGetDTO, User>();
            CreateMap<User, UserGetDTO>();
        }
    }
}
