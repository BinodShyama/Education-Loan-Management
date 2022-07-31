using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Queries.GetUserByUserName
{
   public class GetUserByUserNameQuery : IRequest<User>
    {
        public string userName { get; set; }
        public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User>
        {
            private readonly ApplicationDbContext _context;

            public GetUserByUserNameQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
            {

                return await _context.User.Where(c => c.UserName == request.userName).FirstOrDefaultAsync();
            }
        }

    }
}