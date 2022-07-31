using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetUniversityList
{
  public  class GetUniverssityListQuery : IRequest<List<string>>
    {
        public class GetUniverssityListQueryHandler : IRequestHandler<GetUniverssityListQuery, List<string>>
        {
            private readonly ApplicationDbContext _db;
            public GetUniverssityListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<string>> Handle(GetUniverssityListQuery request, CancellationToken cancellationToken)
            {
                return await _db.MemberLoanDetail.Select(c => c.University).Distinct().ToListAsync();
            }


        }
    }
}

