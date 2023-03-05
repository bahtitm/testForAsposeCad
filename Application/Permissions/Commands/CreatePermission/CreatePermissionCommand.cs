using Domain.Enums;
using MediatR;

namespace Application.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommand : IRequest
    {
        public int RoleId { get; set; }
        public ClaimType ClaimType { get; set; }
        public ClaimValue ClaimValue { get; set; }
    }
}
