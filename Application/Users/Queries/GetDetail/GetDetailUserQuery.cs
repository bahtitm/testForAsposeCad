using Application.Users.Dtos;
using MediatR;

namespace Application.Users.Queries.GetDetail
{
    public class GetDetailUserQuery : IRequest<UserDto>
    {
        public GetDetailUserQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
