using MediatR;
using System;

namespace Twitter.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<string>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
