using Application.Roles.Commands.CreateRole;
using Application.Roles.Commands.UpdateRole;
using Application.Roles.Dtos;
using AutoMapper;
using Domain;

namespace Application.Roles.MappingProfile
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<Role, RoleDto>();
        }
    }
}
