using LoanManagement.Application.Provinces.Queries.GetDistricts;
using LoanManagement.Application.Provinces.Queries.GetProvinces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvienceController : BaseController
    {
        public async Task<IActionResult> GetProviences()
        {
            return Ok(await Mediator.Send(new GetProvinceListQuery()));
        }
     
    }
}
