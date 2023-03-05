using Application.Comments.Dtos;
using MediatR;

namespace Application.Comments.Queries.GetAll
{
    public class GetAllCommentQuery : IRequest<IQueryable<CommentDto>>
    {
    }
}
