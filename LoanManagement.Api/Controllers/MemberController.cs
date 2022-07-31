using LoanManagement.Application.Members.Queries.GetMemberList;
using LoanManagement.Service.Members.Commands.Create;
using LoanManagement.ViewModel.Members;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<MemberListDto>> GetMemberList()
        {
            return Ok(await Mediator.Send(new GetMemberListQuery()));
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
