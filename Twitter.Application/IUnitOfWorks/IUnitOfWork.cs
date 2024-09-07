using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IRepositorys;

namespace Twitter.Application.IUnitOfWorks
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        //Task<int> CommitAsync();
        void Commit();
        Task CommitAsync();
        void Rollback();
        Task RollbackAsync();
    }
}
