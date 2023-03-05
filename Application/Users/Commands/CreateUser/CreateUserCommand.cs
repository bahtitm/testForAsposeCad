using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string? Name { get; set; }
        public string? LastNamre { get; set; }
        public string? MidelName { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
    }
}
