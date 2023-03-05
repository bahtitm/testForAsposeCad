using MediatR;

namespace Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest
    {
        public string? Name { get; set; }
    }
}
