using AutoMapper;
using DataAccess.Interfaces;
using Domain;
using MediatR;

namespace Application.Permissions.Commands.CreatePermission
{
    public class CreatePermissionCommandHandler : AsyncRequestHandler<CreatePermissionCommand>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;
        public CreatePermissionCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected override async Task Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
        {
            var permission = mapper.Map<Permission>(request);
            await dbContext.AddAsync(permission);
            await dbContext.SaveChangesAsync();
        }
    }
}
