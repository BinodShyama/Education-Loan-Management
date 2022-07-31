using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetDegreeList
{
    public class GetDegreeListQuery : IRequest<List<string>>
    {
        public class GetDegreeListQueryHandler : IRequestHandler<GetDegreeListQuery, List<string>>
        {
            private readonly ApplicationDbContext _db;
            public GetDegreeListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<string>> Handle(GetDegreeListQuery request, CancellationToken cancellationToken)
            {
                return await _db.MemberLoanDetail.Select(c => c.Degree).Distinct().ToListAsync();
            }
        }
    }
}

