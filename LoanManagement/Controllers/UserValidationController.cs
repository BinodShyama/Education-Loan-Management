using LoanManagement.Application.Members.Queries.GetMemberList;
using LoanManagement.Application.Members.Queries.GetMemberPostList;
using LoanManagement.Application.Users.Queries.CheckDuplicateEmail;
using LoanManagement.Application.Users.Queries.CheckDuplicateUserName;
using LoanManagement.ViewModel.Datatable;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class UserValidationController : BaseController
    {

        private readonly IMediator _mediator;

        public UserValidationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CheckDuplicateEmail")]
        public async Task<JsonResult> CheckDuplicateEmail(string email, string id)
        {
            bool exists = await _mediator.Send(new CheckDuplicateEmailQuery { email=email, id = id });
            return Json(!exists);
        }

        [HttpPost(Name = "CheckDuplicateUserName")]
        public async Task<JsonResult> CheckDuplicateUserName(string userName, string id)
        {
            bool exists = await _mediator.Send(new CheckDuplicateUserNameQuery { userName = userName, id = id });
            return Json(!exists);
        }

        [HttpPost]
        [Route("/member/List")]
        public async Task<JsonResult> MemberList(DataTablePostModel model, MemberSearchModel searchModel)
        {
            var dt = await _mediator.Send(new GetMemberPostListQuery { dtModel=model,searchModel=searchModel});
            return Json(dt);
        }
    }
}
