using Application.Comments.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;

namespace Application.Comments.Queries.GetAll
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, IQueryable<CommentDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllCommentQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Comment>().ProjectTo<CommentDto>(mapper.ConfigurationProvider));
        }
    }
}
