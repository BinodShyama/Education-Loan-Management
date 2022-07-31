using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Users.Queries.CheckDuplicateEmail
{
    public class CheckDuplicateEmailQuery : IRequest<bool>
    {
        public string email { get; set; }
        public string id { get; set; }
        public class CheckDuplicateEmailQueryHandler : IRequestHandler<CheckDuplicateEmailQuery, bool>
        {
            private readonly ApplicationDbContext _context;

            public CheckDuplicateEmailQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CheckDuplicateEmailQuery request, CancellationToken cancellationToken)
            {

                return await _context.User.Where(c => c.Email == request.email && c.Id != request.id).AnyAsync();
            }
        }
    }
}