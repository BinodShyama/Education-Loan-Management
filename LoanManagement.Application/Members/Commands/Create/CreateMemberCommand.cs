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

namespace LoanManagement.Service.Members.Commands.Create
{
    public class CreateMemberCommand:IRequest<ResponseModel<MemberDetailDto>>
    {
        public MemberDetailDto memberDto { get; set; }
        public string CreatedBy { get; set; }
        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, ResponseModel<MemberDetailDto>>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;
            public CreateMemberCommandHandler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ResponseModel<MemberDetailDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                try {
                    request.memberDto.Id = Guid.NewGuid().ToString();
                    var member = _mapper.Map<Member>(request.memberDto);
                    member.CreatedBy = request.CreatedBy;
                    member.CreatedDate = DateTime.Now;
                    member.Status = true;
                    var model = _dbContext.Member.Add(member);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    var resultData= _mapper.Map<MemberDetailDto>(model.Entity);
                    return new ResponseModel<MemberDetailDto> { Data = resultData, Status = true, Messages = new List<string> { "Successfully Saved." } };
                }
                catch(Exception ex)
                {
                    return new ResponseModel<MemberDetailDto> { Data = request.memberDto, Status = false, Messages = new List<string> { "Faild to save data." } };
                }
            }
        }
    }
}
