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

namespace LoanManagement.Application.Members.Queries.GetMemberDetailById
{
    public class GetMemberSummaryByIdQuery : IRequest<MemberSummaryViewDto>
    {
        public string MemberId { get; set; }
        public class GetMemberDetailByIdQueryHandler : IRequestHandler<GetMemberSummaryByIdQuery, MemberSummaryViewDto>
        {
            private readonly ApplicationDbContext _db;

            public GetMemberDetailByIdQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<MemberSummaryViewDto> Handle(GetMemberSummaryByIdQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var dt = await _db.Member.Where(c => c.Id.ToLower() == request.MemberId.ToLower()).Include(c => c.MemberLoan).Select(c => new MemberSummaryViewDto
                    {
                        Id = c.Id,
                        Name = $"{c.FirstName}{(string.IsNullOrEmpty(c.MiddleName) ? "" : (c.MiddleName).Trim() == "" ? "" : " " + (c.MiddleName))} {c.LastName}",
                        BirthofDateBS = c.BirthofDateBS,
                        CitizenShipNumber = c.CitizenShipNumber,
                        NationalIdentiryCardNumber = c.NationalIdentiryCardNumber,
                        SanctionAmount = $"Rs.  {c.MemberLoan.LoanAmount.ToString("0.00")}",
                        Address = $"{c.PermanentStreet} {c.PermanentWardNumber}, {c.PermanentMunicipality}",
                        MemberId = c.CustomMemberId.ToString(),
                        ContactNo = c.MobileNumber,
                        MaturityDate = c.MemberLoan.LoanMaturityDateNep,
                        LoanId = c.MemberLoan.Id
                    }).FirstOrDefaultAsync();
                    var disbruseInstallment = (_db.LoanDisbrusement.Include(c => c.LoanDisbrusementDetail).Where(c => c.MemberId == request.MemberId)).SelectMany(c => c.LoanDisbrusementDetail).Select(c => c.InstallmentId).Distinct().ToList();

                    var installments = await _db.MemberLoanInstallment.Where(c => c.MemberLoanDetailId == dt.LoanId).OrderBy(c=>c.InstallmentNo).Select(c => new InstallmentdDetail
                    {
                        InstallmentId=c.Id.ToString(),
                        Installment=$"Installment {c.InstallmentNo}",
                        Disbrused= c.Disbrused,
                        Amount= c.Amount.ToString("0.00"),
                    }).ToListAsync();
                    if(disbruseInstallment.Count>0 && installments.Count > 0)
                    {
                        installments = installments.Where(c => !disbruseInstallment.Contains(c.InstallmentId.ToString())).ToList();
                    }
                        
                    dt.Installments = installments;
                    return dt;
                }
                catch(Exception ex)
                {
                    return new MemberSummaryViewDto();
                }
            }
        }
    }
}
