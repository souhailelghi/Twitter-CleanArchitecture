using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IRepositorys.IGenericRepo;
using Twitter.Domain.Models;

namespace Twitter.Application.IRepositorys
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
