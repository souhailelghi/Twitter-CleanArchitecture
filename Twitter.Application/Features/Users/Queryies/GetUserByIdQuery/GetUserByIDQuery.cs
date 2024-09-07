using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Queryies.GetUserByIdQuery
{
    public class GetUserByIDQuery : IRequest<User>
    {
        public Guid Id { get; set; }
        public GetUserByIDQuery(Guid idUser)
        {
            Id = idUser;
        }
    }
}
