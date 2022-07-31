using LoanManagement.Domain;
using LoanManagement.ViewModel.LoanDisbrusement;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.LoanDisbrusements.Queries.GetLoanDisbrusemantList
{
   public class GetLoanDisbrusementListQuery:IRequest<ResponseModel<List<LoanDisbrusementListDto>>>
    {
        public class GetLoanDisbrusementListQueryHandler : IRequestHandler<GetLoanDisbrusementListQuery, ResponseModel<List<LoanDisbrusementListDto>>>
        {
            private readonly ApplicationDbContext _db;

            public GetLoanDisbrusementListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<ResponseModel<List<LoanDisbrusementListDto>>> Handle(GetLoanDisbrusementListQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var model = await _db.LoanDisbrusement.Include(c => c.Member).Select(c => new LoanDisbrusementListDto { 
                    Id=c.Id,
                    Action="",
                    Amount=$"Rs. {c.Amount.ToString("0.00")}",
                    Bank=c.BankName,
                    ChequeDate=c.ChequeDate,
                    ChequeNo=c.ChequeNo,
                    Name= $"<a class='btn-link' href='/member/view/{c.MemberId}'>{c.Member.FirstName}{(string.IsNullOrEmpty(c.Member.MiddleName) ? "" : (c.Member.MiddleName).Trim() == "" ? "" : " " + (c.Member.MiddleName))} {c.Member.LastName}</a>",
                    Remarks=c.Note,
                    Status= c.Status? $"<span class='badge badge-pill badge-info'>Active</span>" : $"<span class='badge badge-pill badge-waring'>Cancel</span>",
                    VoucherDateNep=c.VoucherDateNep,
                    VoucherDate=c.VoucherDate,
                    VoucherNo= $"<a class='btn-link' href='/Loandisbrusement/view/{c.Id}'>{c.VoucherNo}</a>"
                    }).ToListAsync();
                    return new ResponseModel<List<LoanDisbrusementListDto>> { Data = model, Messages = new List<string>() { "Data fetched successfully" }, Status = true };
                }catch(Exception ex)
                {
                    return new ResponseModel<List<LoanDisbrusementListDto>>{ Data = new List<LoanDisbrusementListDto>(), Messages = new List<string>() { "Fail to fetch record" }, Status = false };
                }
            }
        }
    }
}
