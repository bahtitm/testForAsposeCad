using Application.Roles.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;

namespace Application.Roles.Queries.GetAll
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IQueryable<RoleDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllRoleQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<RoleDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<Role>().ProjectTo<RoleDto>(mapper.ConfigurationProvider));
        }
    }
}
