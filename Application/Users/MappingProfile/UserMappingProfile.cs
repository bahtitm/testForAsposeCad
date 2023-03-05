using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Dtos;
using AutoMapper;
using Domain;

namespace Application.Users.MappingProfile
{
    internal class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDto>();
            CreateMap<Permission, UserPermissionDto>();
        }
    }
}
