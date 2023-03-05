using MediatR;

namespace Application.Posts.Commands.DeleteDocument
{
    public class DeletePostCommand : IRequest
    {
        public DeletePostCommand(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
