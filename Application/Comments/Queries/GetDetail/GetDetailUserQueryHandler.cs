using Application.Comments.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Comments.Queries.GetDetail
{
    public class GetDetailCommentQueryHandler : IRequestHandler<GetDetailCommentQuery, CommentDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<CommentDto> Handle(GetDetailCommentQuery request, CancellationToken cancellationToken)
        {
            var comment = await dbContext.FindByIdAsync<Comment>(request.Id);
            return mapper.Map<CommentDto>(comment);
        }
    }
}
