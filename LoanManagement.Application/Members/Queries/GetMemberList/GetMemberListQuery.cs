using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.ViewModel.Members;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Queries.GetMemberList
{
   public class GetMemberListQuery:IRequest<List<MemberListDto>>
    {
        public class GetMemberListQueryHandler : IRequestHandler<GetMemberListQuery, List<MemberListDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetMemberListQueryHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<MemberListDto>> Handle(GetMemberListQuery request, CancellationToken cancellationToken)
            {

               return await _context.Member.Include(c => c.MemberLoan).Select(c => new MemberListDto {
                    Id = c.Id,
                    Name =  $"<a class='btn-link' href='/member/view/{c.Id}'>{c.FirstName}{(string.IsNullOrEmpty(c.MiddleName) ? "" : (c.MiddleName).Trim()==""?"":" "+(c.MiddleName))} {c.LastName}</a>",
                    BirthofDateBS = c.BirthofDateBS,
                    CitizenShipNumber = c.CitizenShipNumber,
                   NationalIdentiryCardNumber=c.NationalIdentiryCardNumber,
                    Email = c.Email,
                    Gender = c.Gender,
                    GrandFatherName = c.GrandFatherFullName,
                    FatherName=c.FatherFullName,
                    MobileNumber = c.MobileNumber,
                    Tole=c.PermanentStreet,
                    WardNumber = c.PermanentWardNumber,
                    HouseNo = c.PermanentHouseNo,
                    SanctionAmount = c.MemberLoan.LoanAmount,
                   Address=$"{c.PermanentStreet} {c.PermanentWardNumber}, {c.PermanentMunicipality}",
                    SanctionAmountStr = c.MemberLoan.LoanAmount.ToString("0.00")=="0.00"? $"<a href='/MemberLoanDetail/Create/{c.Id}'><span class='badge badge-pill badge-warning'>Not Allocated</span></a>" : $"<a href='/MemberLoanDetail/Edit/{c.Id}'><span class='badge badge-pill badge-info'>Rs. {c.MemberLoan.LoanAmount.ToString("0.00")}</span></a>"
               
                }).ToListAsync();
                //return _mapper.Map<List<MemberDetailDto>>(await _context.Member.ToListAsync());
            }
        }
    }
}
