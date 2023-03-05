using Application.Posts.Dtos;
using MediatR;

namespace Application.Posts.Queries.GetSearchedPost
{
    public class GetSearchedPostQuery : IRequest<IQueryable<PostDto>>
    {
        public GetSearchedPostQuery(string search)
        {
            Search = search;
        }

        public string Search { get; }
    }
}
