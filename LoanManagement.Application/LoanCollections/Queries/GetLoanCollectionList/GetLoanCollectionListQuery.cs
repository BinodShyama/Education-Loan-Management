using LoanManagement.Domain;
using LoanManagement.ViewModel.LoanCollections;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.LoanCollections.Queries.GetLoanCollectionList
{
    public class GetLoanCollectionListQuery : IRequest<ResponseModel<List<LoanCollectionListDto>>>
    {
        public class GetLoanCollectionListQueryHandler : IRequestHandler<GetLoanCollectionListQuery, ResponseModel<List<LoanCollectionListDto>>>
        {
            private readonly ApplicationDbContext _db;

            public GetLoanCollectionListQueryHandler(ApplicationDbContext db)
            {
                _db = db;
            }

            public async Task<ResponseModel<List<LoanCollectionListDto>>> Handle(GetLoanCollectionListQuery request, CancellationToken cancellationToken)
            {
                try
                {
                    var model = await _db.LoanCollection.Include(c => c.Member).Select(c => new LoanCollectionListDto
                    {
                        Id = c.Id,
                        Action = "<a href='#' type ='button' title='View voucher' class='btn btn-default btn-icon'><i class='fa-solid fa-eye'></i></a><a type = 'button' href='#' class='btn btn-default btn-icon' title='Print voucher'><i class='fa-solid fa-print'></i></a><a href='#' type = 'button' title='Cancel voucher' class='btn btn-default btn-icon'><i class='fa-solid fa-eraser'></i></a>",
                        Amount = $"Rs. {c.Amount.ToString("0.00")}",
                        Name = $"<a class='btn-link' href='/member/view/{c.MemberId}'>{c.Member.FirstName}{(string.IsNullOrEmpty(c.Member.MiddleName) ? "" : (c.Member.MiddleName).Trim() == "" ? "" : " " + (c.Member.MiddleName))} {c.Member.LastName}</a>",
                        Remarks = c.Note,
                        Status = c.Status ? $"<span class='badge badge-pill badge-info'>Active</span>" : $"<span class='badge badge-pill badge-waring'>Cancel</span>",
                        VoucherDate = c.DateNep,
                        VoucherNo = c.VoucherNo
                    }).ToListAsync();
                    return new ResponseModel<List<LoanCollectionListDto>> { Data = model, Messages = new List<string>() { "Data fetched successfully" }, Status = true };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<List<LoanCollectionListDto>> { Data = new List<LoanCollectionListDto>(), Messages = new List<string>() { "Fail to fetch record" }, Status = false };
                }
            }
            
        }
    }
}
