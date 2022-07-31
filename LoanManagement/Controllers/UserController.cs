using LoanManagement.Application.Users.Commands.Create;
using LoanManagement.Application.Users.Commands.Update;
using LoanManagement.Application.Users.Queries.GetUserById;
using LoanManagement.Helpers.Activity;
using LoanManagement.ViewModel.Activity;
using LoanManagement.ViewModel.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IActivity _activity;

        public UserController(IMediator mediator, IActivity activity)
        {
            _mediator = mediator;
            _activity = activity;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new CreateUserCommand { userCreateDto = model });
                if (result.Status)
                {
                    _activity.Status.Show(StatusType.Success, string.Join(",", result.Messages));
                    return Redirect("/user/index");
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

        public async Task<IActionResult> EditAsync(string id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { id = id });
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, UserUpdateDto model)
        {
            {
                if (ModelState.IsValid)
                {
                    var result = await _mediator.Send(new UpdateUserCommand { userUpdateDto = model, id = id });
                    _activity.Status.Show(result.Status ? StatusType.Success : StatusType.Error, string.Join(",", result.Messages));
                    return Redirect("/user/index");
                }
                else
                {
                    _activity.Status.Show(StatusType.Error, string.Join("\n", ModelState.Values.SelectMany(c => c.Errors).Select(e => e.ErrorMessage).ToList()));
                    return View(model);
                }
            }
        }

    }
}
