

using LoanManagement.Application.Users.Queries.GetUserList;
using LoanManagement.ViewModel.Datatable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetUserList()
        {
            var dt = await Mediator.Send(new GetUserListQuery());
            return Ok(new DataTableResponseModel() { data = dt, draw = 0, recordsFiltered = 0, recordsTotal = dt.Count() });
        }
    }
}
