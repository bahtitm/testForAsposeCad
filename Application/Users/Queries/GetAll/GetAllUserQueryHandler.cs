using Application.Users.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataAccess.Interfaces;
using Domain;
using MediatR;

namespace Application.Users.Queries.GetAll
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IQueryable<UserDto>>
    {
        private readonly IApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public GetAllUserQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IQueryable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(dbContext.Set<User>().ProjectTo<UserDto>(mapper.ConfigurationProvider));
        }
    }
}
