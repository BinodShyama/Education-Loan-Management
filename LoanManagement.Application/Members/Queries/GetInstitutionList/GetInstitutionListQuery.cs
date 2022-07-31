using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetInstitutionList
{
  public  class GetInstitutionListQuery : IRequest<List<string>>
    {
        public class GetInstitutionListQueryHandler : IRequestHandler<GetInstitutionListQuery, List<string>>
        {
            private readonly ApplicationDbContext _db;
            public GetInstitutionListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<string>> Handle(GetInstitutionListQuery request, CancellationToken cancellationToken)
            {
                return await _db.MemberLoanDetail.Select(c => c.Institution).Distinct().ToListAsync();
            }

          
        }
    }
}

