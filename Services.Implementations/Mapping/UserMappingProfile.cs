using AutoMapper;
using Core.Entity;
using Core.Entity.Entities;
using Services.Contracts.Users;

namespace Services.Implementations.Mapping;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();

        CreateMap<CreateUserDto, User>()
            //.ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.IsActiveUser, m => m.Ignore())
            //.ForMember(d=> d.NotificationTypes, m => m.Ignore())
            .ForMember(d=> d.SecondName, m => m.Ignore())
            .ForMember(d=> d.Email, m => m.Ignore())
            .ForMember(d=> d.UserType, m => m.Ignore())
            .ForMember(d=> d.DateCreated, m => m.Ignore());

        CreateMap<UpdateUserDto, User>()
            .ForMember(d => d.Id, m => m.Ignore())
            .ForMember(d => d.DateCreated, m => m.Ignore());
    }
}