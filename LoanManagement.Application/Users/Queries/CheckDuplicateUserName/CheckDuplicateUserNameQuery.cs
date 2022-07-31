using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Queries.CheckDuplicateUserName
{
    public class CheckDuplicateUserNameQuery : IRequest<bool>
    {
        public string userName { get; set; }
        public string id { get; set; }
        public class CheckDuplicateEmailQueryHandler : IRequestHandler<CheckDuplicateUserNameQuery, bool>
        {
            private readonly ApplicationDbContext _context;

            public CheckDuplicateEmailQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CheckDuplicateUserNameQuery request, CancellationToken cancellationToken)
            {

                return await _context.User.Where(c => c.UserName == request.userName && c.Id != request.id).AnyAsync();
            }
        }

    }
}