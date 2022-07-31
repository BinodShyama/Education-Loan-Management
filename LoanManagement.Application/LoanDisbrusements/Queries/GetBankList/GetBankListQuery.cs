using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.LoanDisbrusements.Queries.GetBankList
{
   public class GetBankListQuery:IRequest<List<string>>
    {
        public class GetBankListQueryHandler : IRequestHandler<GetBankListQuery, List<string>>
        {
            private readonly ApplicationDbContext _db;

            public GetBankListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<string>> Handle(GetBankListQuery request, CancellationToken cancellationToken)
            {
                return await _db.LoanDisbrusement.Select(c => c.BankName).Distinct().ToListAsync();
            }
        }
    }
}
