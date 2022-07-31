using LoanManagement.Application.Members.Queries.GetUniversityList;
using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetWardList
{
  public  class GetWardListQuery : IRequest<List<string>>
    {
        public class GetWardListQueryHandler : IRequestHandler<GetWardListQuery, List<string>>
        {
            private readonly ApplicationDbContext _db;
            public GetWardListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<List<string>> Handle(GetWardListQuery request, CancellationToken cancellationToken)
            {
                return await _db.Member.Select(c => c.PermanentWardNumber).Distinct().ToListAsync();
            }


        }
    }
}