using Application.Users.Dtos;
using MediatR;

namespace Application.Users.Queries.GetAll
{
    public class GetAllUserQuery : IRequest<IQueryable<UserDto>>
    {
    }
}
