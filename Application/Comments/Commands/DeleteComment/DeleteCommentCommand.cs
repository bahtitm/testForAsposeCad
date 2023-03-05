using MediatR;

namespace Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest
    {
        public DeleteCommentCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
