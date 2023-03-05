using Application.Posts.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Posts.Commands.UpdateDocument
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdatePostCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PostDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var document = await dbContext.FindByIdAsync<Post>(request.Id);
            mapper.Map(request, document);
            await dbContext.SaveChangesAsync();
            return mapper.Map<PostDto>(document);
        }
    }
}
