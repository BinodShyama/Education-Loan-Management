using LoanManagement.Application.LoanDisbrusements.Commands.CreateLoanDisbrusement;
using LoanManagement.Application.LoanDisbrusements.Queries.GetBankList;
using LoanManagement.Application.LoanDisbrusements.Queries.GetLoanDisbrusemantList;
using LoanManagement.Application.LoanDisbrusements.Queries.GetLoanDisbursementById;
using LoanManagement.Application.Members.Queries.GetMemberDetailById;
using LoanManagement.Application.Members.Queries.GetMemberSerchList;
using LoanManagement.Helpers.Activity;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Datatable;
using LoanManagement.ViewModel.LoanDisbrusement;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Authorize]
    public class LoanDisbrusementController : BaseController
    {
        private readonly string _baseUrl;

        private readonly IMediator _mediator;
        private readonly IActivity _activity;
        private readonly IAccountService _accountService;

        public LoanDisbrusementController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IActivity activity, IAccountService account)
        {
            _baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
            _mediator = mediator;
            _activity = activity;
            _accountService = account;
        }

        public IActionResult Index() => View();
        public async Task<IActionResult> Create()
        {
            ViewBag.Member = (await _mediator.Send(new GetMemberSelectListQuery())).Select(c => new SelectListItem { Value = c.Value, Text = c.Text });
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(LoanDisbrusementCreateDto loanDisbrusementCreateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateLoanDisbrusementCommand { loanDisbrusementCreateDto = loanDisbrusementCreateDto, CreatedBy = _accountService.GetLoggedinUserId() });
                _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                return Redirect("Index");
            }
            else
            {
                _activity.Status.Show(StatusType.Error, string.Join(",", ModelState.Select(c => c.Value.Errors).ToList()));
                return Redirect("create");
            }
        }

        public async Task<IActionResult> GetSummary(string id)
        {
            return Json(await _mediator.Send(new GetMemberSummaryByIdQuery { MemberId = id }));
        }
        public async Task<IActionResult> GetBankList(string id)
        {
            return Json(await _mediator.Send(new GetBankListQuery()));
        }

        public async Task<IActionResult> ViewAsync(string id)
        {
            ViewBag.Member = (await _mediator.Send(new GetMemberSelectListQuery())).Select(c => new SelectListItem { Value = c.Value, Text = c.Text });
            var model = await _mediator.Send(new GetLoanDisbrusementByIdQuery { id = id });
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> GetLoanDisbrusementList()
        {
            var dt = await _mediator.Send(new GetLoanDisbrusementListQuery());
            return Ok(new DataTableResponseModel() { data = dt.Data, draw = 0, recordsFiltered = 0, recordsTotal = dt.Data.Count() });
        }

        [HttpGet]
        public async Task<ActionResult> GetLoanDisbrusementVoucher(string id)
        {
            return await Task.Run(() => ViewComponent("PaymentVoucher", new { id=id}));
        }
    }
}
