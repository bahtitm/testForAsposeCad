using Application.Posts.Dtos;
using MediatR;

namespace Application.Posts.Commands.UpdateDocument
{
    public class UpdatePostCommand : IRequest<PostDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? UserId { get; set; }
    }
}
