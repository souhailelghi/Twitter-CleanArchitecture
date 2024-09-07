using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserQuery : IRequest<string>
    {
        public Guid IdUser { get; set; }
        public DeleteUserQuery(Guid idUser)
        {
            IdUser = idUser;
        }
        
    }
}
