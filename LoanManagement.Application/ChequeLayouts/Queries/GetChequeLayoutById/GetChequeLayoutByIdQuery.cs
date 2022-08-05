using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Cheque;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutById
{
  public  class GetChequeLayoutByIdQuery : IRequest<ChequeLayoutDto>
    {
        public string id { get; set; }
        public class GetChequeLayoutByIdQueryHandler : IRequestHandler<GetChequeLayoutByIdQuery, ChequeLayoutDto>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetChequeLayoutByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ChequeLayoutDto> Handle(GetChequeLayoutByIdQuery request, CancellationToken cancellationToken)
            {
                var layout = await _context.ChequeLayout.Where(c => c.Id == request.id).FirstOrDefaultAsync();

                if (layout != null)
                {
                    return _mapper.Map<ChequeLayoutDto>(layout);
                }
                else
                    return new ChequeLayoutDto();
            }

        }
    }
}