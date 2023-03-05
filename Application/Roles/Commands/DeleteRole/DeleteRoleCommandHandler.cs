using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteRoleCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await dbContext.FindByIdAsync<Role>(request.Id);
            dbContext.Set<Role>().Remove(role);
            await dbContext.SaveChangesAsync();
        }
    }
}
