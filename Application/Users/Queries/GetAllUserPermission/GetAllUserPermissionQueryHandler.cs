using Application.Users.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;
using Shared;

namespace Application.Users.Queries.GetAllUserPermission
{
    public class GetAllUserPermissionQueryHandler : IRequestHandler<GetAllUserPermissionQuery, IQueryable<UserPermissionDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllUserPermissionQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<UserPermissionDto>> Handle(GetAllUserPermissionQuery request, CancellationToken cancellationToken)
        {
            var user = dbContext.Set<User>().Where(p => p.Name.Equals(request.Name)).FirstOrDefault();
            if (user == null) return null;

            var hasUser = user.Password.Equals(StringHelper.GetMd5Sum(request.Password));
            var permissions = new List<Permission>();
            if (hasUser)
            {
                
                if (user?.Role?.Permissions != null)
                {
                    permissions.AddRange(user.Role.Permissions);
                }
                return await Task.FromResult(permissions.AsQueryable().ProjectTo<UserPermissionDto>(mapper.ConfigurationProvider));
            }

            return null;
        }

    }
}
