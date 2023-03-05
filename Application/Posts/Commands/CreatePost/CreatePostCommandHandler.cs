using AutoMapper;
using DataAccess.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Posts.Commands.CreatePost
{
    public class CreatePostCommandHandler : AsyncRequestHandler<CreatePostCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;        

        public CreatePostCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            
        }

        protected override async Task Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            
            var document = mapper.Map<Post>(request);
            await dbContext.AddAsync(document);
            await dbContext.SaveChangesAsync();
        }
    }

}

