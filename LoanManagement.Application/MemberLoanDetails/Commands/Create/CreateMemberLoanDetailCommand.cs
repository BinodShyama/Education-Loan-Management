using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Members;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.MemberLoanDetails.Commands.Create
{
  public  class CreateMemberLoanDetailCommand: IRequest<ResponseModel<MemberLoanDetailDto>>
    {

        public MemberLoanDetailDto memberLoanDto { get; set; }
        public string CreatedBy { get; set; }
        public class CreateMemberLoanDetailCommandHandler : IRequestHandler<CreateMemberLoanDetailCommand, ResponseModel<MemberLoanDetailDto>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public CreateMemberLoanDetailCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }


            public async Task<ResponseModel<MemberLoanDetailDto>> Handle(CreateMemberLoanDetailCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var serialNo = 0;
                    try
                    {
                        serialNo = _dbContext.MemberLoanDetail.Max(c => c.SerialNo) + 1;
                    }
                    catch
                    {
                        serialNo = 1;
                    }
                    request.memberLoanDto.LoanAccountNo = $"LAC-{serialNo.ToString("00000")}";
                    request.memberLoanDto.Id = Guid.NewGuid().ToString();
                    var dt = _mapper.Map<MemberLoanDetail>(request.memberLoanDto);
                    dt.CreatedDate = DateTime.Now;
                    dt.Status = true;
                    dt.SerialNo = serialNo;
                    dt.CreatedBy = request.CreatedBy;
                    var installments = new List<MemberLoanInstallment> { new MemberLoanInstallment { Id= Guid.NewGuid().ToString(), InstallmentNo=1, Amount = dt.Installment1,CreatedBy= request.CreatedBy }, new MemberLoanInstallment { Id = Guid.NewGuid().ToString(),InstallmentNo =2, Amount = dt.Installment2,CreatedBy= request.CreatedBy }, new MemberLoanInstallment { Id = Guid.NewGuid().ToString(),InstallmentNo =3, Amount = dt.Installment3 ,CreatedBy= request.CreatedBy } };
                    dt.Installments = installments;

                    var model = _dbContext.MemberLoanDetail.Add(dt);
                   
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    var resultData = _mapper.Map<MemberLoanDetailDto>(model.Entity);
                    return new ResponseModel<MemberLoanDetailDto> { Data = resultData, Status = true, Messages = new List<string> { $"{resultData.LoanAccountNo} created successfully." } };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<MemberLoanDetailDto> { Data = request.memberLoanDto, Status = false, Messages = new List<string> { "Faild to save data." } };
                }
            }
        }
    }
}
