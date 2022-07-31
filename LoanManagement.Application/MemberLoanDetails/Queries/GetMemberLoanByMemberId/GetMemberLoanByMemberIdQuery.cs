using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Members;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.MemberLoanDetails.Queries.GetMemberLoanByMemberId
{
  public  class GetMemberLoanByMemberIdQuery : IRequest<ResponseModel<MemberLoanDetailDto>>
    {
        public string Id { get; set; }
        public class GetMemberLoanByMemberIdQueryHandler : IRequestHandler<GetMemberLoanByMemberIdQuery, ResponseModel<MemberLoanDetailDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetMemberLoanByMemberIdQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<MemberLoanDetailDto>> Handle(GetMemberLoanByMemberIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var dt = _mapper.Map<MemberLoanDetailDto>(await _context.MemberLoanDetail.Where(c => c.MemberId.ToLower() == request.Id.ToLower()).FirstOrDefaultAsync(cancellationToken));
                    if (dt != null)
                        return new ResponseModel<MemberLoanDetailDto>() { Data = dt, Status = true, Messages = new List<string>() { "Data fetched successfully." } };
                    return new ResponseModel<MemberLoanDetailDto>() { Data = new MemberLoanDetailDto(), Status = false, Messages = new List<string>() { "No record available" } };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<MemberLoanDetailDto>() { Data = new MemberLoanDetailDto(), Status = false, Messages = new List<string>() { ex.Message } };
                }
            }
        }
    }
}
