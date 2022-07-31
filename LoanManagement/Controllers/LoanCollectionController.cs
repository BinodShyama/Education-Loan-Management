using LoanManagement.Application.LoanCollections.Commands.CreateLoanCollection;
using LoanManagement.Application.LoanCollections.Queries.GetLoanCollectionList;
using LoanManagement.Application.Members.Queries.GetMemberSerchList;
using LoanManagement.Helpers.Activity;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Datatable;
using LoanManagement.ViewModel.LoanCollections;
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
    public class LoanCollectionController:BaseController
    {
        private readonly string _baseUrl;

        private readonly IMediator _mediator;
        private readonly IActivity _activity;
        private readonly IAccountService _accountService;

        public LoanCollectionController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IActivity activity, IAccountService accountService)
        {
            _baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
            _mediator = mediator;
            _activity = activity;
            _accountService = accountService;
        }

        public IActionResult Index() => View();
        public async Task<IActionResult> Create(string id)
        {
            ViewBag.Member = (await _mediator.Send(new GetMemberSelectListQuery())).Select(c => new SelectListItem { Value = c.Value, Text = c.Text });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LoanCollectionCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateLoanCollectionCommand { LoanCollectionModel = model,CreatedBy= _accountService.GetLoggedinUserId() });
                _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                return Redirect("Index");
            }
            else
            {
                _activity.Status.Show(StatusType.Error, string.Join(",", ModelState.Select(c => c.Value.Errors).ToList()));
                return Redirect("create");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetLoanCollectionList()
        {
            var dt = await _mediator.Send(new GetLoanCollectionListQuery());
            return Ok(new DataTableResponseModel() { data = dt.Data, draw = 0, recordsFiltered = 0, recordsTotal = dt.Data.Count() });
        }
    }
}
