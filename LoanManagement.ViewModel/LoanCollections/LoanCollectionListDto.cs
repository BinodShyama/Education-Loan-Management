using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.LoanCollections
{
    public class LoanCollectionListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string Amount { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
