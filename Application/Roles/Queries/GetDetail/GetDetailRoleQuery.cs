using Application.Roles.Dtos;
using MediatR;

namespace Application.Roles.Queries.GetDetail
{
    public class GetDetailRoleQuery : IRequest<RoleDto>
    {
        public GetDetailRoleQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
