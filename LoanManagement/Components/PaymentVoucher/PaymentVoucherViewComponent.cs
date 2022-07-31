using LoanManagement.Application.LoanDisbrusements.Queries.GetLoanDisbursementById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Components.PaymentVoucher
{
    public class PaymentVoucherViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public PaymentVoucherViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var model = await _mediator.Send(new GetLoanDisbrusementByIdQuery { id = id });
            return View(model);
        }
    }
}
