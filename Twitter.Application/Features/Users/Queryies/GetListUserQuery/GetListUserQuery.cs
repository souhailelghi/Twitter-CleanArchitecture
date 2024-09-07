using MediatR;
using Twitter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Features.Users.Queryies.GetListUserQuery
{
    public class GetListUserQuery : IRequest<List<User>>
    {

    }
}
