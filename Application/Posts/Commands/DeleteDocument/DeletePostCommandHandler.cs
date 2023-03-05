using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Posts.Commands.DeleteDocument
{
    public class DeletePostCommandHandler : AsyncRequestHandler<DeletePostCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeletePostCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Post>(request.Id);
            dbContext.Set<Post>().Remove(document);
            await dbContext.SaveChangesAsync();
        }
    }
}
