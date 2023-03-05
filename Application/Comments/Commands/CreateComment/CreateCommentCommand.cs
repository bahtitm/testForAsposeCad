using MediatR;

namespace Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int DocumentId { get; set; }
    }
}
