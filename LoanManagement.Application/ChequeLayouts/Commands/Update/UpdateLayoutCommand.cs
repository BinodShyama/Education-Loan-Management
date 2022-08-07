using AutoMapper;
using LoanManagement.Domain;
using LoanManagement.Domain.Entities;
using LoanManagement.ViewModel.Cheque;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Commands.Update
{
    public class UpdateLayoutCommand : IRequest<ResponseModel<ChequeLayoutDto>>
    {
        public ChequeLayoutDto model { get; set; }
        public string id { get; set; }
        public class UpdateLayoutCommandHandler : IRequestHandler<UpdateLayoutCommand, ResponseModel<ChequeLayoutDto>>
        {
            private readonly ApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdateLayoutCommandHandler(ApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ResponseModel<ChequeLayoutDto>> Handle(UpdateLayoutCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var layout = await _context.ChequeLayout.Where(c => c.Id == request.id).AsNoTracking().FirstOrDefaultAsync();
                    if (layout != null)
                    {
                        request.model.Id = layout.Id;
                        request.model.CreatedBy = layout.CreatedBy;
                        request.model.CreatedDate = layout.CreatedDate;
                        layout = _mapper.Map<ChequeLayout>(request.model);
                        _context.Update<ChequeLayout>(layout);
                        await _context.SaveChangesAsync(cancellationToken);
                        return new ResponseModel<ChequeLayoutDto> { Data = request.model, Messages = new List<string> { "Successfully saved data." }, Status = true };
                    }
                    else
                        return new ResponseModel<ChequeLayoutDto> { Data = request.model, Messages = new List<string> { "Failed to save layout." }, Status = false };

                }
                catch (Exception ex)
                {
                    return new ResponseModel<ChequeLayoutDto> { Data = request.model, Messages = new List<string> { "Failed to save layout." }, Status = false };
                }
            }

        }
    }
}