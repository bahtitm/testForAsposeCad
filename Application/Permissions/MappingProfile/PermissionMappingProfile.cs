using Application.Permissions.Commands.CreatePermission;
using Application.Permissions.Commands.UpdatePermission;
using Application.Permissions.Dtos;
using AutoMapper;
using Domain;

namespace Application.Permissions.MappingProfile
{
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {
            CreateMap<CreatePermissionCommand, Permission>();
            CreateMap<UpdatePermissionCommand, Permission>();
            CreateMap<Permission, PermissionDto>();
        }
    }
}
