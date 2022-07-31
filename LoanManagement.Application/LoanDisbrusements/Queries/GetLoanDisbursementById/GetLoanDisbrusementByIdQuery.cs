using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.LoanDisbrusement;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.LoanDisbrusements.Queries.GetLoanDisbursementById
{
    public class GetLoanDisbrusementByIdQuery : IRequest<LoanDisbrusementViewDto>
    {
        public string id { get; set; }
        public class GetLoanDisbrusementByIdQueryHandler : IRequestHandler<GetLoanDisbrusementByIdQuery,  LoanDisbrusementViewDto>
        {
            private readonly IMapper _mapper;
            private readonly ApplicationDbContext _db;

            public GetLoanDisbrusementByIdQueryHandler(IMapper mapper, ApplicationDbContext db)
            {
                _mapper = mapper;
                _db = db;
            }

            public async Task<LoanDisbrusementViewDto> Handle(GetLoanDisbrusementByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var model = _mapper.Map<LoanDisbrusementViewDto>(await _db.LoanDisbrusement.Include(c=>c.LoanDisbrusementDetail).Where(c => c.Id == request.id).FirstOrDefaultAsync());
                    if (model != null)
                    {
                        return model;
                    }
                    else
                        return new LoanDisbrusementViewDto();
                }
                catch(Exception ex)
                {
                    return new LoanDisbrusementViewDto();
                }
            }
        }
    }
}
