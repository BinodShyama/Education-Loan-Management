using AutoMapper;
using LoanManagement.Application.Helpers.Extensions;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
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

namespace LoanManagement.Application.LoanDisbrusements.Commands.CreateLoanDisbrusement
{
    public class CreateLoanDisbrusementCommand : IRequest<ResponseModel<LoanDisbrusementCreateDto>>
    {
        public LoanDisbrusementCreateDto loanDisbrusementCreateDto { get; set; }
        public string CreatedBy { get; set; }
        public class CreateLoanDisbrusementCommandHandler : IRequestHandler<CreateLoanDisbrusementCommand, ResponseModel<LoanDisbrusementCreateDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CreateLoanDisbrusementCommandHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<LoanDisbrusementCreateDto>> Handle(CreateLoanDisbrusementCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var voucher = 0;
                    try
                    {
                        voucher = _context.LoanDisbrusement.Max(c => c.TransactionId) + 1;
                    }
                    catch
                    {
                        voucher = 1;
                    }
                    var loanDisbrusement = _mapper.Map<LoanDisbrusement>(request.loanDisbrusementCreateDto);
                    var voucherDate = request.loanDisbrusementCreateDto.VoucherDateNep;
                    loanDisbrusement.VoucherDate =  request.loanDisbrusementCreateDto.VoucherDateNep.ConvertoNepaliDate();
                    loanDisbrusement.VoucherNo = $"LD-{voucher.ToString("0000")}";
                    loanDisbrusement.TransactionId = voucher;
                    loanDisbrusement.CreatedBy = request.CreatedBy;
                    var loanDisbrusementDetail = new List<LoanDisbrusementDetail>();
                    if (request.loanDisbrusementCreateDto.Installments != null)
                    {
                        var intallments = await _context.MemberLoanInstallment.Where(c => request.loanDisbrusementCreateDto.Installments.Contains(c.Id)).AsNoTracking().ToListAsync();
                        foreach (var item in request.loanDisbrusementCreateDto.Installments)
                        {
                            var install = intallments.Where(c => c.Id == item).FirstOrDefault();
                            if (install != null)
                            {
                                loanDisbrusementDetail.Add(new LoanDisbrusementDetail
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    CreatedDate = DateTime.Now,
                                    VoucherNo = loanDisbrusement.VoucherNo,
                                    Status = true,
                                    Amount = install.Amount,
                                    Description = $"Installment No {install.InstallmentNo}",
                                    InstallmentId=item,
                                    CreatedBy= request.CreatedBy
                                });
                            }
                        }
                        loanDisbrusement.LoanDisbrusementDetail = loanDisbrusementDetail;
                    }
                    var transactionDetail = new List<TransactionDetail>
                    {
                        new TransactionDetail
                        {
                            Id= Guid.NewGuid().ToString(),
                            Particular=$"Bank A/c({request.loanDisbrusementCreateDto.BankName})",
                            CrAmount=request.loanDisbrusementCreateDto.Amount,
                            DrAmount=0,
                            CreatedDate=DateTime.Now,
                            Status=true,
                            Order=1,
                            CreatedBy=request.CreatedBy
                        },
                        new TransactionDetail
                        {
                            Id= Guid.NewGuid().ToString(),
                            Particular=$"Loan A/C ({request.loanDisbrusementCreateDto.MemberName})",
                            DrAmount=request.loanDisbrusementCreateDto.Amount,
                            CrAmount=0,
                            CreatedDate=DateTime.Now,
                            Status=true,
                            Order=2,
                            CreatedBy=request.CreatedBy
                        }
                    };

                    var tranaction = new Transaction
                    {
                        Id = Guid.NewGuid().ToString(),
                        MemberId = request.loanDisbrusementCreateDto.MemberId,
                        Amount = request.loanDisbrusementCreateDto.Amount,
                        CreatedDate = DateTime.Now,
                        Note = request.loanDisbrusementCreateDto.Note,
                        Particular = "Loan disbrusement",
                        VoucherDateNep = request.loanDisbrusementCreateDto.VoucherDateNep,
                        VoucherNo = loanDisbrusement.VoucherNo,
                        VoucherDate = DateTime.Now,
                        TransactionDetail = transactionDetail,
                        Status = true,
                        VoucherIndex = voucher,
                        CreatedBy= request.CreatedBy
                    };
                    _context.LoanDisbrusement.Add(loanDisbrusement);
                    _context.Transaction.Add(tranaction);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel<LoanDisbrusementCreateDto> { Status = true, Data = null, Messages = new List<string>() { "Data saved successfully." } };

                }
                catch (Exception ex)
                {
                    return new ResponseModel<LoanDisbrusementCreateDto> { Status = false, Data = null, Messages = new List<string>() { "Fail to save data" } };
                }
            }
        }
    }
}
