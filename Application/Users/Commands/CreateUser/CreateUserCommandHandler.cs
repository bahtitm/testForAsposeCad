using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;
using Shared;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreateUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            user.Password = StringHelper.GetMd5Sum(request.Password);
            var role= await dbContext.FindByIdAsync<Role>(1);
            user.Role = role;
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

    }

}

