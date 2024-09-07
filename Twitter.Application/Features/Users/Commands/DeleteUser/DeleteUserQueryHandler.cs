using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IUnitOfWorks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserQueryHandler : IRequestHandler<DeleteUserQuery, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public Task<string> Handle(DeleteUserQuery request, CancellationToken cancellationToken)
        {
           _unitOfWork.UserRepository.GetById(request.IdUser);
           
            _unitOfWork.UserRepository.Delete(request.IdUser);
            _unitOfWork.CommitAsync();
            return Task.FromResult("User deleted successfully");
        }
    }
}
