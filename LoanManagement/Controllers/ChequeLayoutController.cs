using LoanManagement.Application.ChequeLayouts.Commands.Create;
using LoanManagement.Application.ChequeLayouts.Commands.Delete;
using LoanManagement.Application.ChequeLayouts.Commands.Update;
using LoanManagement.Application.ChequeLayouts.Queries.CheckDuplicateLayoutName;
using LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutById;
using LoanManagement.Application.ChequeLayouts.Queries.GetChequeLayoutList;
using LoanManagement.Helpers.Activity;
using LoanManagement.Helpers.Extensions;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Cheque;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IChequePrint _chequePrint;
        public ChequeLayoutController(IMediator mediator, IActivity activity, IAccountService accountService, IChequePrint chequePrint)
        {
            _mediator = mediator;
            _activity = activity;
            _accountService = accountService;
            _chequePrint = chequePrint;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            var chequeLayout = new ChequeLayoutDto();
            return await Task.Run(() => View(chequeLayout));
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
                var result = await _mediator.Send(new UpdateLayoutCommand { model = model, id = id });
                if (result.Status)
                {
                    _activity.Status.Show(StatusType.Success, string.Join(",", result.Messages));
                    return Redirect("/chequelayout/index");
                }
                else
                {
                    _activity.Status.Show(StatusType.Error, string.Join(",", result.Messages));
                }
            }
            else
                _activity.Status.Show(StatusType.Error, string.Join(",", ModelState.Select(c => c.Value.Errors).ToList()));
            return View(model);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _mediator.Send(new DeleteLayoutCommand { Id = id });
            return Json(result);
            //_activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
            //return Redirect("/chequelayout/index");
        }

        [HttpPost(Name = "ChequeValiation")]
        public async Task<JsonResult> ChequeValiation(string name, string id)
        {
            if (string.IsNullOrEmpty(id))
                id = Guid.NewGuid().ToString();
            bool exists = await _mediator.Send(new CheckDuplicateLayoutNameQuery { Name = name, Id = id });
            return Json(!exists);
        }

        [HttpPost]
        public async Task<JsonResult> PrintByLayout(string id, ChequeDataDto chequeData)
        {
            return Json(await _chequePrint.Print(id, chequeData));
        }

        [HttpPost]
        public async Task<JsonResult> Print(ChequeLayoutDto layout, ChequeDataDto chequedata)
        {
            //var layout = JsonConvert.DeserializeObject<ChequeLayoutDto>(layoutStr);
            //var data = JsonConvert.DeserializeObject<ChequeDataDto>(dataStr);
            return Json(await Task.Run(()=>  _chequePrint.Print(layout, chequedata)));
        }

    }
}
