using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IServices;
using Twitter.Application.IUnitOfWorks;

namespace Twitter.Application.Servecies
{
    public class UserService : IUserService
    {
        #region Props
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region Constructor
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion


    }
}
