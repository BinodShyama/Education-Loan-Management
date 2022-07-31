using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.LoanDisbrusement
{
    public class LoanDisbrusementListDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string VoucherDateNep { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherNo { get; set; }
        public string Amount { get; set; }
        public string Bank { get; set; }
        public string ChequeNo { get; set; }
        public string ChequeDate { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
