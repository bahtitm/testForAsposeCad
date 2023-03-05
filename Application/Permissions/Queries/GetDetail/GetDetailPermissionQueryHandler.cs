using Application.Permissions.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Permissions.Queries.GetDetail
{
    public class GetDetailPermissionQueryHandler : IRequestHandler<GetDetailPermissionQuery, PermissionDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PermissionDto> Handle(GetDetailPermissionQuery request, CancellationToken cancellationToken)
        {
            var permission = await dbContext.FindByIdAsync<Permission>(request.Id);
            return mapper.Map<PermissionDto>(permission);
        }
    }
}
