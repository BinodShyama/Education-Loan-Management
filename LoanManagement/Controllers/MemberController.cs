using LoanManagement.Application.MemberLoanDetails.Queries.GetMemberLoanByMemberId;
using LoanManagement.Application.Members.Commands.Update;
using LoanManagement.Application.Members.Queries.GetMemberById;
using LoanManagement.Helpers.Activity;
using LoanManagement.Service.Members.Commands.Create;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Address;
using LoanManagement.ViewModel.Members;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    [Authorize]
    public class MemberController : BaseController
    {
        private readonly string _baseUrl;

        private readonly IMediator _mediator;
        private readonly IActivity _activity;
        private readonly IAccountService _accountService;
        public MemberController(IHttpContextAccessor httpContextAccessor, IMediator mediator, IActivity activity,IAccountService accountService)
        {
            _baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
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

            var district = (await GetAsync<List<DistrictDto>>($"{_baseUrl}/api/District")).OrderBy(c => c.Name);

            ViewBag.District = district.Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
            ViewBag.Provience = (await GetAsync<List<ProvinceDto>>($"{_baseUrl}/api/Provience")).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 3 ? true : false) });
            ViewBag.DistrictByProvience = district.Where(c => c.ProvinceId == 3).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
            ViewBag.Dis = district;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberDetailDto model)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateMemberCommand { memberDto = model,CreatedBy= _accountService.GetLoggedinUserId() });
                if (result.Status)
                {
                    _activity.Status.Show(StatusType.Success , string.Join(",", result.Messages));
                    if ((await _mediator.Send(new GetMemberLoanByMemberIdQuery { Id = result.Data.Id })).Status)
                        return Redirect($"/MemberLoanDetail/Edit/{result.Data.Id}");
                    else
                        return Redirect($"/MemberLoanDetail/Create/{result.Data.Id}");
                }
                else
                {
                    var district = (await GetAsync<List<DistrictDto>>($"{_baseUrl}/api/District")).OrderBy(c => c.Name);

                    ViewBag.District = district.Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                    ViewBag.Provience = (await GetAsync<List<ProvinceDto>>($"{_baseUrl}/api/Provience")).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 3 ? true : false) });
                    ViewBag.DistrictByProvience = district.Where(c => c.ProvinceId == 3).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                    ViewBag.Dis = district;
                    _activity.Status.Show(StatusType.Error, string.Join(",", result.Messages));
                    return View(model);
                }
            }
            else
            {
                var district = (await GetAsync<List<DistrictDto>>($"{_baseUrl}/api/District")).OrderBy(c => c.Name);

                ViewBag.District = district.Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                ViewBag.Provience = (await GetAsync<List<ProvinceDto>>($"{_baseUrl}/api/Provience")).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 3 ? true : false) });
                ViewBag.DistrictByProvience = district.Where(c => c.ProvinceId == 3).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                ViewBag.Dis = district;
                _activity.Status.Show(StatusType.Error, string.Join("\n", ModelState.Values.SelectMany(c => c.Errors).Select(e => e.ErrorMessage).ToList()));
                return View(model);
            }
        }

        public async Task<IActionResult> View(string id)
        {

            var result = await _mediator.Send(new GetMemberByIdQuery { Id = id });
            if (result.Status)
            {
                var district = (await GetAsync<List<DistrictDto>>($"{_baseUrl}/api/District")).OrderBy(c => c.Name);

                ViewBag.District = district.Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                ViewBag.Provience = (await GetAsync<List<ProvinceDto>>($"{_baseUrl}/api/Provience")).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 3 ? true : false) });
                ViewBag.DistrictByProvience = district.Where(c => c.ProvinceId == 3).Select(c => new SelectListItem { Text = c.Name, Value = c.Name.ToString(), Selected = (c.Id == 23 ? true : false) });
                ViewBag.Dis = district;

                return View(result.Data);
            }
            else
            {
                _activity.Status.Show(StatusType.Warning, string.Join(",", result.Messages.ToList()));
                return Redirect("/member/index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, MemberDetailDto model)
        {
            if (ModelState.IsValid)
            {
                var dtResult = await _mediator.Send(new GetMemberByIdQuery { Id = id });
                if (dtResult.Status)
                {
                    var result = await _mediator.Send(new UpdateMemberCommand { memberDto = model,UpdatedBy=_accountService.GetLoggedinUserId() });
                    _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                }
                else
                    _activity.Status.Show(StatusType.Error, string.Join(",", dtResult.Messages));
            }
            else
                _activity.Status.Show(StatusType.Error, string.Join(",", ModelState.Select(c => c.Value.Errors).ToList()));
            return Redirect("/member/index");
        }

    }
}
