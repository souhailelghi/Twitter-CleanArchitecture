using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.IRepositorys.IGenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(Guid id);


        T Add(T entity);


        T Update(Guid id, T entity);
        void Delete(Guid id);
    }
}
