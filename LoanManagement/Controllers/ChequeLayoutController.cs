using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Controllers
{
    public class ChequeLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
