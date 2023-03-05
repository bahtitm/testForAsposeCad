using Application.Posts.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Posts.Queries.GetDetail
{
    public class GetDetailPostQueryHandler : IRequestHandler<GetDetailPostQuery, PostDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailPostQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<PostDto> Handle(GetDetailPostQuery request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Post>(request.Id);
            return mapper.Map<PostDto>(document);
        }
    }
}
