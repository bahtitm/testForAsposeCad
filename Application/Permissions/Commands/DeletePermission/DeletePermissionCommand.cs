using MediatR;

namespace Application.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommand : IRequest
    {
        public DeletePermissionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
