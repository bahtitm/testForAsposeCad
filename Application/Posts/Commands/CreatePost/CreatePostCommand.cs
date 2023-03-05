using MediatR;

namespace Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest
    {
       
        public string? Name { get; set; }
        public string? Description { get; set; }
        
    }
}
