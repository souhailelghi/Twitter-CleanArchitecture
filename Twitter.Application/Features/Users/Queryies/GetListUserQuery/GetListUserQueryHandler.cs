using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.IServices;
using Twitter.Application.IUnitOfWorks;
using Twitter.Domain.Models;

namespace Twitter.Application.Features.Users.Queryies.GetListUserQuery
{
    public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, List<User>>
    {
        //private readonly IUnitOfService _unitOfService;
        private readonly IUnitOfWork _unitOfWork;

        public GetListUserQueryHandler( IUnitOfWork unitOfWork)
        {
            //_unitOfService = unitOfService;
            _unitOfWork = unitOfWork;
        }
        
        public Task<List<User>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            List<User> users= _unitOfWork.UserRepository.GetAll().ToList();
            return Task.FromResult(users);
        }
    }
}
