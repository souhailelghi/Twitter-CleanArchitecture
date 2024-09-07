using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IUnitOfWorks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Queryies.GetUserByIdQuery
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUserByIDQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<User> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            User user = _unitOfWork.UserRepository.GetById(request.Id);
            return Task.FromResult(user);
        }
    }
}
