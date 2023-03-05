using Application.Posts.Dtos;
using MediatR;

namespace Application.Posts.Queries.GetDetail
{
    public class GetDetailPostQuery : IRequest<PostDto>
    {
        public GetDetailPostQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
