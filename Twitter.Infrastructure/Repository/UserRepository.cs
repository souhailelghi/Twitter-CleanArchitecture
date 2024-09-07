using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IRepositorys;
using Twitter.Domain.Models;
using Twitter.Infrastructure.Data;
using Twitter.Infrastructure.GenericRepository;

namespace Twitter.Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
