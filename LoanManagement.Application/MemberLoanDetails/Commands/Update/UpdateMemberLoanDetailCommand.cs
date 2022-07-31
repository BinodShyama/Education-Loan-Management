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

namespace LoanManagement.Application.MemberLoanDetails.Commands.Update
{
   public class UpdateMemberLoanDetailCommand : IRequest<ResponseModel<MemberLoanDetailDto>>
    {

        public MemberLoanDetailDto memberLoanDto { get; set; }
        public string UpdatedBy { get; set; }
        public class UpdateMemberLoanDetailCommandHandler : IRequestHandler<UpdateMemberLoanDetailCommand, ResponseModel<MemberLoanDetailDto>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public UpdateMemberLoanDetailCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }


            public async Task<ResponseModel<MemberLoanDetailDto>> Handle(UpdateMemberLoanDetailCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    request.memberLoanDto.Id = Guid.NewGuid().ToString();
                    var dt = _mapper.Map<MemberLoanDetail>(request.memberLoanDto);
                    dt.UpdateDate = DateTime.Now;
                    dt.UpdatedBy = request.UpdatedBy;
                    var installments = new List<MemberLoanInstallment> { new MemberLoanInstallment { Id = Guid.NewGuid().ToString(), InstallmentNo = 1, Amount = dt.Installment1 ,CreatedBy= request.UpdatedBy ,UpdatedBy= request.UpdatedBy }, new MemberLoanInstallment { Id = Guid.NewGuid().ToString(),InstallmentNo = 2, Amount = dt.Installment2 ,CreatedBy=request.UpdatedBy,UpdatedBy= request.UpdatedBy }, new MemberLoanInstallment { Id = Guid.NewGuid().ToString(),InstallmentNo = 3, Amount = dt.Installment3,CreatedBy= request.UpdatedBy,UpdatedBy= request.UpdatedBy } };

                    var inst = _dbContext.MemberLoanInstallment.Where(c => c.MemberLoanDetailId == request.memberLoanDto.Id);
                     _dbContext.MemberLoanInstallment.RemoveRange(inst);

                    dt.Installments = installments;

                    var model = _dbContext.MemberLoanDetail.Update(dt);

                    await _dbContext.SaveChangesAsync(cancellationToken);
                    var resultData = _mapper.Map<MemberLoanDetailDto>(model.Entity);
                    return new ResponseModel<MemberLoanDetailDto> { Data = resultData, Status = true, Messages = new List<string> { "Successfully Saved." } };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<MemberLoanDetailDto> { Data = request.memberLoanDto, Status = false, Messages = new List<string> { "Faild to save data." } };
                }
            }
        }
    }
}
