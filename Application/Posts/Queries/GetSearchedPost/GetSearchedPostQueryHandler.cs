using Application.Posts.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Posts.Queries.GetSearchedPost
{
    public class GetSearchedPostQueryHandler : IRequestHandler<GetSearchedPostQuery, IQueryable<PostDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetSearchedPostQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<IQueryable<PostDto>> Handle(GetSearchedPostQuery request, CancellationToken cancellationToken)
        {
            var serchString = $"%{request.Search}%";
            return await Task.FromResult(dbContext.Set<Post>().Where(p => EF.Functions.Like(p.Name.ToLower(), serchString.ToLower()) || EF.Functions.Like(p.Description.ToLower(), serchString.ToLower())).ProjectTo<PostDto>(mapper.ConfigurationProvider));
        }
    }
}
