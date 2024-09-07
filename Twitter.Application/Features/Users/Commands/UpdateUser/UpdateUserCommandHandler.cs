using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Twitter.Application.IUnitOfWorks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _unitOfWork.UserRepository.GetById(request.Id);
            if (user == null)
            {
                return "User not found.";
            }

            user.Name = request.Name;
            user.Email = request.Email;
            user.Password = request.Password; // Handle securely
            user.Phone = request.Phone;

            _unitOfWork.UserRepository.Update(request.Id, user);
            await _unitOfWork.CommitAsync();

            return "User updated successfully";
        }
    }
}
