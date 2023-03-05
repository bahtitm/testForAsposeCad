using Application.Roles.Dtos;
using AutoMapper;
using DataAccess.Interfaces;
using DataAccess.Interfaces.Extensions;
using Domain;
using MediatR;

namespace Application.Roles.Queries.GetDetail
{
    public class GetDetailRoleQueryHandler : IRequestHandler<GetDetailRoleQuery, RoleDto>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetDetailRoleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetDetailRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await dbContext.FindByIdAsync<Role>(request.Id);
            return mapper.Map<RoleDto>(role);
        }
    }
}
