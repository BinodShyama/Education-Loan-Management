using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Queries.CheckDuplicateLayoutName
{
   public class CheckDuplicateLayoutNameQuery:IRequest<bool>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public class CheckDuplicateLayoutNameQueryHandler : IRequestHandler<CheckDuplicateLayoutNameQuery, bool>
        {
            private readonly ApplicationDbContext _context;

            public CheckDuplicateLayoutNameQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(CheckDuplicateLayoutNameQuery request, CancellationToken cancellationToken)
            {
                return await _context.ChequeLayout.Where(c => c.Id.ToLower() != request.Id.ToLower() && c.Name.ToLower() == request.Name.ToLower()).AnyAsync(cancellationToken);
            }
        }
    }
}
