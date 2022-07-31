using LoanManagement.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LoanManagement.Application.Members.Queries.GetMemberSerchList
{
    public class GetMemberSelectListQuery:IRequest<List<SelectListItem>>
    {
        public class GetMemberSelectListQueryHandler : IRequestHandler<GetMemberSelectListQuery, List<SelectListItem>>
        {
            private readonly ApplicationDbContext _context;

            public GetMemberSelectListQueryHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<List<SelectListItem>> Handle(GetMemberSelectListQuery request, CancellationToken cancellationToken)
            {
                return await _context.Member.Where(c=>c.MemberLoan!=null).Select(c => new SelectListItem { Text = $"{c.FirstName} {c.MiddleName} {c.LastName}" , Value = c.Id }).ToListAsync();
            }
        }
    }
}
