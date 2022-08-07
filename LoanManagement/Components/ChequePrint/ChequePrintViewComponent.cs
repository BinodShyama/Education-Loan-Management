using LoanManagement.ViewModel.Cheque;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Components.ChequePrint
{
    public class ChequePrintViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            return await Task.Run(()=> View(new ChequeDataDto()));
        }
    }
}
