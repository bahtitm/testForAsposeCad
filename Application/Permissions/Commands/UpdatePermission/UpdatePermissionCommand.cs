using Application.Permissions.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.Permissions.Commands.UpdatePermission
{
    public class UpdatePermissionCommand : IRequest<PermissionDto>
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }
}
