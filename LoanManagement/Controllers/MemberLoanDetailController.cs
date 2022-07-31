using LoanManagement.Application.MemberLoanDetails.Commands.Create;
using LoanManagement.Application.MemberLoanDetails.Commands.Update;
using LoanManagement.Application.MemberLoanDetails.Queries.GetMemberLoanByMemberId;
using LoanManagement.Application.Members.Queries.GetMemberById;
using LoanManagement.Helpers.Activity;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Address;
using LoanManagement.ViewModel.Members;
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
    public class MemberLoanDetailController : BaseController
    {
        private readonly string _baseUrl;

        private readonly IMediator _mediator;
        private readonly IActivity _activity;
        private readonly IAccountService _accountService;

        public MemberLoanDetailController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IActivity activity, IAccountService accountService)
        {
            _baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
            _mediator = mediator;
            _activity = activity;
            _accountService = accountService;

        }
        // GET: ContractController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContractController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContractController/Create
        public async Task<ActionResult> Create(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _activity.Status.Show(StatusType.Warning, "No Member found");
                return Redirect("member/index");
            }
            else
            {
                var result = await _mediator.Send(new GetMemberByIdQuery { Id = id });
                if (!result.Status)
                {
                    _activity.Status.Show(StatusType.Warning, string.Join(",", result.Messages.ToList()));
                    return Redirect("/member/index");
                }
                else
                {
                    if ((await _mediator.Send(new GetMemberLoanByMemberIdQuery { Id = id })).Status)
                        return Redirect($"/MemberLoanDetail/Edit/{result.Data.Id}");

                    ViewBag.Id = result.Data.Id;
                    ViewBag.MemberId = result.Data.MemberId;
                    ViewBag.Name = $"{result.Data.FirstName} {result.Data.MiddleName?.Trim()} {result.Data.LastName}";
                    return View();
                }

            }

        }

        // POST: ContractController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MemberLoanDetailDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateMemberLoanDetailCommand { memberLoanDto = model, CreatedBy=_accountService.GetLoggedinUserId()});
                _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                return Redirect("/member/index");
            }
            else
            {
                _activity.Status.Show(StatusType.Error, string.Join("\n", ModelState.Values.SelectMany(c => c.Errors).Select(e => e.ErrorMessage).ToList()));
                return View(model);
            }
        }

        // GET: ContractController/Edit/5
        public async Task<ActionResult> EditAsync(string id)
        {
            var response = await _mediator.Send(new GetMemberLoanByMemberIdQuery { Id = id });
            if (response.Status)
            {
                var result = await _mediator.Send(new GetMemberByIdQuery { Id = id });
                ViewBag.Id = result.Data.Id;
                ViewBag.MemberId = result.Data.MemberId;
                ViewBag.Name = $"{result.Data.FirstName} {result.Data.MiddleName?.Trim()} {result.Data.LastName}";
                return View(response.Data);
            }
            else
            {
                _activity.Status.Show(StatusType.Warning, string.Join(",", response.Messages.ToList()));
                return Redirect("/member/index");
            }    
        }

        // POST: ContractController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, MemberLoanDetailDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new UpdateMemberLoanDetailCommand { memberLoanDto = model, UpdatedBy=_accountService.GetLoggedinUserId() });
                _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                return Redirect("/member/index");
            }
            else
            {
                _activity.Status.Show(StatusType.Error, string.Join("\n", ModelState.Values.SelectMany(c => c.Errors).Select(e => e.ErrorMessage).ToList()));
                return View(model);
            }
        }

        // GET: ContractController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContractController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
