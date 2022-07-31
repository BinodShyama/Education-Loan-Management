using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Datatable
{
   public class DataTableResponseModel
    {
        public int? draw { get; set; }
        public int? recordsTotal { get; set; }
        public int? recordsFiltered { get; set; }

        public bool status { get; set; } = true;
        public object data { get; set; }
    }
}
