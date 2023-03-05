using Application.Permissions.Dtos;
using MediatR;

namespace Application.Permissions.Queries.GetAll
{
    public class GetAllPermissionQuery : IRequest<IQueryable<PermissionDto>>
    {
    }
}
