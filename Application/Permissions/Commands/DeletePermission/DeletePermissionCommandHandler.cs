using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Permissions.Commands.DeletePermission
{
    public class DeletePermissionCommandHandler : AsyncRequestHandler<DeletePermissionCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeletePermissionCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeletePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = await dbContext.FindByIdAsync<Permission>(request.Id);
            dbContext.Set<Permission>().Remove(permission);
            await dbContext.SaveChangesAsync();
        }
    }
}
