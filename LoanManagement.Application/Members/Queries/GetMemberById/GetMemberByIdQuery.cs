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

namespace LoanManagement.Application.Members.Queries.GetMemberById
{
    public class GetMemberByIdQuery : IRequest<ResponseModel<MemberDetailDto>>
    {
        public string Id { get; set; }
        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, ResponseModel<MemberDetailDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetMemberByIdQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<ResponseModel<MemberDetailDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var dt = _mapper.Map<MemberDetailDto>(await _context.Member.Where(c => c.Id.ToLower() == request.Id.ToLower()).AsNoTracking().FirstOrDefaultAsync());
                    if (dt != null)
                        return new ResponseModel<MemberDetailDto>() { Data = dt, Status = true, Messages = new List<string>() { "Data fetched successfully." } };
                    return new ResponseModel<MemberDetailDto>() { Data = new MemberDetailDto(), Status = false, Messages = new List<string>() { "No record available" } };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<MemberDetailDto>() { Data = new MemberDetailDto(), Status = false, Messages = new List<string>() { ex.Message } };
                }
            }
        }
    }
}
