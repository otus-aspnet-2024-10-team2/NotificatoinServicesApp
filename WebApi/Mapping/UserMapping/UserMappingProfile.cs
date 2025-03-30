using AutoMapper;
using Services.Contracts.Users;
using WebApi.Models.User;

namespace WebApi.Mapping.UserMapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserDto, UserModel>();
        CreateMap<CreateUserDto, CreateUserModel>();
        CreateMap<UpdateUserDto, UpdateUserModel>();
    }
}