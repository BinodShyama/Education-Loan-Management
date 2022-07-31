using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.LoanCollections;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.LoanCollections.Commands.CreateLoanCollection
{
    public class CreateLoanCollectionCommand : IRequest<ResponseModel<LoanCollectionCreateDto>>
    {
        public LoanCollectionCreateDto LoanCollectionModel { get; set; }
        public string CreatedBy { get; set; }
        public class CrateLoanCollectionCommadHandler : IRequestHandler<CreateLoanCollectionCommand, ResponseModel<LoanCollectionCreateDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;
            public CrateLoanCollectionCommadHandler(ApplicationDbContext db, IMapper mapper)
            {
                _context = db;
                _mapper = mapper;
            }

            public async Task<ResponseModel<LoanCollectionCreateDto>> Handle(CreateLoanCollectionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var voucher = 0;
                    try
                    {
                        voucher = _context.LoanCollection.Max(c => c.TransactionId) + 1;
                    }
                    catch
                    {
                        voucher = 1;
                    }
                    var loanCollection = _mapper.Map<LoanCollection>(request.LoanCollectionModel);
                    loanCollection.TransactionId = voucher;
                    loanCollection.VoucherNo = $"LC-{voucher.ToString("0000")}";
                    loanCollection.DateNep = request.LoanCollectionModel.VoucherDate;
                    loanCollection.CreatedBy = request.CreatedBy;
                    var loanCollectionDetail = new List<LoanCollectionDetail>();
                    if (request.LoanCollectionModel.InterestAmount != 0)
                    {
                        loanCollectionDetail.Add(new LoanCollectionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Amount = request.LoanCollectionModel.InterestAmount,
                            Status = true,
                            CreatedDate = DateTime.Now,
                            Description = "Intrest",
                            VoucherNo = loanCollection.VoucherNo,
                            CreatedBy= request.CreatedBy
                    });
                    }
                    if (request.LoanCollectionModel.PrincipalAmount != 0)
                    {
                        loanCollectionDetail.Add(new LoanCollectionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Amount = request.LoanCollectionModel.PrincipalAmount,
                            Status = true,
                            CreatedDate = DateTime.Now,
                            Description = "Principal",
                            VoucherNo = loanCollection.VoucherNo,
                            CreatedBy = request.CreatedBy
                        });
                    }
                    if (request.LoanCollectionModel.PenaltyAmount != 0)
                    {
                        loanCollectionDetail.Add(new LoanCollectionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Amount = request.LoanCollectionModel.PenaltyAmount,
                            Status = true,
                            CreatedDate = DateTime.Now,
                            Description = "Penalty",
                            VoucherNo = loanCollection.VoucherNo,
                            CreatedBy = request.CreatedBy
                        });
                    }

                    loanCollection.LoanCollectionDetail = loanCollectionDetail;

                    var transactionDetail = new List<TransactionDetail>();


                    transactionDetail.Add(new TransactionDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        Particular = request.LoanCollectionModel.IsBank ? $"Bank A/c({request.LoanCollectionModel.BankName})" : "Cash A/C.",
                        DrAmount = request.LoanCollectionModel.InterestAmount + request.LoanCollectionModel.PrincipalAmount + request.LoanCollectionModel.PenaltyAmount,
                        CrAmount = 0,
                        CreatedDate = DateTime.Now,
                        Status = true,
                        Order = 1,
                        CreatedBy = request.CreatedBy
                    });
                    if (request.LoanCollectionModel.InterestAmount > 0)
                    {
                        transactionDetail.Add(new TransactionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Particular = "Interest Recivable",
                            DrAmount = request.LoanCollectionModel.InterestAmount,
                            CrAmount = 0,
                            CreatedDate = DateTime.Now,
                            Status = true,
                            Order = 2,
                            CreatedBy = request.CreatedBy
                        });
                        transactionDetail.Add(new TransactionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Particular = $"{request.LoanCollectionModel.MemberName}",
                            DrAmount = 0,
                            CrAmount = request.LoanCollectionModel.InterestAmount,
                            CreatedDate = DateTime.Now,
                            Status = true,
                            Order = 3,
                            CreatedBy = request.CreatedBy
                        });
                        transactionDetail.Add(new TransactionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Particular = $"Interest Income",
                            DrAmount = 0,
                            CrAmount = request.LoanCollectionModel.InterestAmount,
                            CreatedDate = DateTime.Now,
                            Status = true,
                            Order = 4,
                            CreatedBy = request.CreatedBy
                        });
                    }
                    if (request.LoanCollectionModel.PrincipalAmount > 0)
                    {
                        transactionDetail.Add(new TransactionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Particular = $"{request.LoanCollectionModel.MemberName}",
                            DrAmount = 0,
                            CrAmount = request.LoanCollectionModel.PrincipalAmount,
                            CreatedDate = DateTime.Now,
                            Status = true,
                            Order = 5,
                            CreatedBy = request.CreatedBy
                        });
                    };
                    if (request.LoanCollectionModel.PenaltyAmount > 0)
                    {
                        transactionDetail.Add(new TransactionDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            Particular = $"Penalty",
                            DrAmount = 0,
                            CrAmount = request.LoanCollectionModel.PenaltyAmount,
                            CreatedDate = DateTime.Now,
                            Status = true,
                            Order = 6,
                            CreatedBy = request.CreatedBy
                        });
                    };


                    var tranaction = new Transaction
                    {
                        Id = Guid.NewGuid().ToString(),
                        MemberId = request.LoanCollectionModel.MemberId,
                        Amount = request.LoanCollectionModel.InterestAmount + request.LoanCollectionModel.PrincipalAmount + request.LoanCollectionModel.PenaltyAmount,
                        CreatedDate = DateTime.Now,
                        Note = request.LoanCollectionModel.Note,
                        Particular = "Loan disbrusement",
                        VoucherDateNep = request.LoanCollectionModel.VoucherDate,
                        VoucherNo = loanCollection.VoucherNo,
                        VoucherDate = DateTime.Now,
                        TransactionDetail = transactionDetail,
                        Status = true,
                        VoucherIndex = voucher,
                        CreatedBy = request.CreatedBy
                    };
                    _context.LoanCollection.Add(loanCollection);
                    _context.Transaction.Add(tranaction);
                    await _context.SaveChangesAsync(cancellationToken);

                    return new ResponseModel<LoanCollectionCreateDto> { Status = true, Data = null, Messages = new List<string>() { "Data saved successfully." } };

                }
                catch (Exception ex)
                {
                    return new ResponseModel<LoanCollectionCreateDto>
                    {
                        Status = false,
                        Data = null,
                        Messages = new List<string>() { "Fail to save data" }
                    };
                }
            }
        }
    }
}
