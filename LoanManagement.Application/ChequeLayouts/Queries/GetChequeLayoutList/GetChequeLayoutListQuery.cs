using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Cheque;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutList
{
   public class GetChequeLayoutListQuery: IRequest<List<ChequeLayoutDto>>
    {
        public class GetChequeLayoutListQueryHandler : IRequestHandler<GetChequeLayoutListQuery, List<ChequeLayoutDto>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

            public GetChequeLayoutListQueryHandler(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<List<ChequeLayoutDto>> Handle(GetChequeLayoutListQuery request, CancellationToken cancellationToken)
            {
                return _mapper.Map<List<ChequeLayoutDto>>(await _db.ChequeLayout.ToListAsync(cancellationToken));
            }
        }
    }
}
