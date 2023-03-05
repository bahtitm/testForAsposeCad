using Application.Users.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public UpdateUserCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await dbContext.FindByIdAsync<User>(request.Id);
            mapper.Map(request, user);
            await dbContext.SaveChangesAsync();
            return mapper.Map<UserDto>(user);
        }
    }
}
