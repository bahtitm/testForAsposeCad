using Application.Posts.Dtos;
using MediatR;

namespace Application.Posts.Queries.GetAll
{
    public class GetAllPostQuery : IRequest<IQueryable<PostDto>>
    {
    }
}
