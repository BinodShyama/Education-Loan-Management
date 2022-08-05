using LoanManagement.Application.ChequeLayouts.Commands.Create;
using LoanManagement.Application.ChequeLayouts.Commands.Update;
using LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutById;
using LoanManagement.Helpers.Activity;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Cheque;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class ChequeLayoutController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IActivity _activity;
        private readonly IAccountService _accountService;

        public ChequeLayoutController(IMediator mediator, IActivity activity, IAccountService accountService)
        {
            _mediator = mediator;
            _activity = activity;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChequeLayoutDto model)
        {

            if (ModelState.IsValid)
            {
                model.CreatedBy = _accountService.GetLoggedinUserId();
                model.CreatedDate = DateTime.Now;
                var result = await _mediator.Send(new CreateLayoutCommand { model = model });
                if (result.Status)
                {
                    _activity.Status.Show(StatusType.Success, string.Join(",", result.Messages));
                    return Redirect("/ChequeLayout/Index");
                }
                else
                {
                    _activity.Status.Show(StatusType.Error, string.Join(",", result.Messages));
                    return View(model);
                }
            }
            else
            {
                _activity.Status.Show(StatusType.Error, string.Join("\n", ModelState.Values.SelectMany(c => c.Errors).Select(e => e.ErrorMessage).ToList()));
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {

            var result = await _mediator.Send(new GetChequeLayoutByIdQuery { id = id });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, ChequeLayoutDto model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedBy = _accountService.GetLoggedinUserId();
                model.UpdatedDate = DateTime.Now;
                var result = await _mediator.Send(new UpdateLayoutCommand { model = model, });
                _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
            }
            else
                _activity.Status.Show(StatusType.Error, string.Join(",", ModelState.Select(c => c.Value.Errors).ToList()));
            return Redirect("/member/index");
        }
    }
}
