using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Members;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.Members.Commands.Update
{
   public class UpdateMemberCommand :IRequest<ResponseModel<MemberDetailDto>>
    {
        public MemberDetailDto memberDto { get; set; }
        public string UpdatedBy { get; set; }
        public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, ResponseModel<MemberDetailDto>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public UpdateMemberCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ResponseModel<MemberDetailDto>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var dt = _mapper.Map<Member>(request.memberDto);
                    dt.UpdateDate = DateTime.Now;
                    dt.UpdatedBy = request.UpdatedBy;
                    var model = _dbContext.Member.Update(dt);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    var resultData = _mapper.Map<MemberDetailDto>(model.Entity);
                    return new ResponseModel<MemberDetailDto> { Data = resultData, Status = true, Messages = new List<string> { "Updated sucessfully." } };
                }
                catch (Exception ex)
                {
                    return new ResponseModel<MemberDetailDto> { Data = request.memberDto, Status = false, Messages = new List<string> { "Faild to save data." } };
                }
            }
        }
    }
}
