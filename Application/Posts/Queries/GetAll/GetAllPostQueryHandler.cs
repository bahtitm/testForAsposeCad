using Application.Posts.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;

namespace Application.Posts.Queries.GetAll
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, IQueryable<PostDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllPostQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<PostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Post>().ProjectTo<PostDto>(mapper.ConfigurationProvider));
        }
    }
}
