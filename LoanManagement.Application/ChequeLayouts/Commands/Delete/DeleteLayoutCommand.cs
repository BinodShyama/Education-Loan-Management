using LoanManagement.Domain;
using LoanManagement.ViewModel.ResponseModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanManagement.Application.ChequeLayouts.Commands.Delete
{
   public class DeleteLayoutCommand :IRequest<ResponseModel< bool>>
    {
        public string Id { get; set; }
        public class DeleteLayoutCommandHandler : IRequestHandler<DeleteLayoutCommand, ResponseModel<bool>>
        {
            private readonly ApplicationDbContext _context;

            public DeleteLayoutCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<ResponseModel<bool>> Handle(DeleteLayoutCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var chequeLayout =await _context.ChequeLayout.Where(c => c.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                    _context.ChequeLayout.Remove(chequeLayout);
                    await _context.SaveChangesAsync(cancellationToken);
                    return new ResponseModel<bool>() { Status = true, Data = true, Messages = new List<string>() { "Delete Successfully." } };
                }catch(Exception ex)
                {
                    return new ResponseModel<bool>() { Status = false, Data = false, Messages = new List<string>() { "Fail to delete data." } };
                }
            }
        }
    }
}
