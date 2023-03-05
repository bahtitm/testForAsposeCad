using Application.Permissions.Dtos;
using MediatR;

namespace Application.Permissions.Queries.GetDetail
{
    public class GetDetailPermissionQuery : IRequest<PermissionDto>
    {
        public GetDetailPermissionQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
