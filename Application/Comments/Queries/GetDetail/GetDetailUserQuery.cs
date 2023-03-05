using Application.Comments.Dtos;
using MediatR;

namespace Application.Comments.Queries.GetDetail
{
    public class GetDetailCommentQuery : IRequest<CommentDto>
    {
        public GetDetailCommentQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
