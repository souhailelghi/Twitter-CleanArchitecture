using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IUnitOfWorks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Commands.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password, // Ensure you handle password securely
                Phone = request.Phone
            };

            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Commit();

            return Task.FromResult("added successfully");
        }
    }
}
