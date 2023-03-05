using Application.Roles.Dtos;
using MediatR;

namespace Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<RoleDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
