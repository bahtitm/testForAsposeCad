using Application.Users.Dtos;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
        public string? LastNamre { get; set; }
        public string? MidelName { get; set; }
        public string? Phone { get; set; }
        public int? RoleId { get; set; }
    }
}
