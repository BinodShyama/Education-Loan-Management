using LoanManagement.Application.Members.Queries.GetMemberList;
using LoanManagement.Service.Members.Commands.Create;
using LoanManagement.Sevices;
using LoanManagement.ViewModel.Datatable;
using LoanManagement.ViewModel.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IAccountService _accountService;

        public MemberController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<ActionResult> GetMemberList()
        {
            var dt = await Mediator.Send(new GetMemberListQuery());
            return Ok(new DataTableResponseModel() { data = dt, draw = 0, recordsFiltered = 0, recordsTotal = dt.Count() });
        }

       

        [HttpPost]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create(CreateMemberCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> Update(UpdateAttributeCommand command)
        //{
        //    return Ok(await Mediator.Send(command));
        //}


        //[HttpDelete("{id}")]
        //[ProducesDefaultResponseType]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    return Ok(await Mediator.Send(new DeleteAttributeCommand { Id = id }));
        //}
    }
}
