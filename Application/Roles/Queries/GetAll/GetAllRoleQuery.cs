using Application.Roles.Dtos;
using MediatR;

namespace Application.Roles.Queries.GetAll
{
    public class GetAllRoleQuery : IRequest<IQueryable<RoleDto>>
    {

    }
}
