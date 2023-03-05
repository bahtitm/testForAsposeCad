using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommandHandler : AsyncRequestHandler<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext dbContext;

        public DeleteCommentCommandHandler(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override async Task Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await dbContext.FindByIdAsync<Comment>(request.Id);
            dbContext.Set<Comment>().Remove(comment);
            await dbContext.SaveChangesAsync();
        }
    }
}
