using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Cheque;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Commands.Create
{
    public class CreateLayoutCommand: IRequest<ResponseModel<ChequeLayoutDto>>
    {
        public ChequeLayoutDto model { get; set; }
        public class CreateLayoutCommandHandler : IRequestHandler<CreateLayoutCommand, ResponseModel<ChequeLayoutDto>>
        {
            private readonly ApplicationDbContext _db;
            private readonly IMapper _mapper;

            public CreateLayoutCommandHandler(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<ResponseModel<ChequeLayoutDto>> Handle(CreateLayoutCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    request.model.Id = Guid.NewGuid().ToString();
                    _db.Add(_mapper.Map<ChequeLayout>(request.model));
                    
                    await _db.SaveChangesAsync(cancellationToken);

                    return new ResponseModel<ChequeLayoutDto>
                    {
                        Status = true,
                        Data = request.model,
                        Messages = new List<string>() { "Data saved successfully." }
                    };

                }
                catch(Exception ex)
                {
                    return new ResponseModel<ChequeLayoutDto>
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
