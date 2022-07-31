using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.LoanDisbrusement
{
    public class LoanDisbrusementViewDto
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string VoucherDateNep { get; set; }
        public string VoucherNo { get; set; }
        public decimal Amount { get; set; }
        public string BankName { get; set; }
        public string ChequeDate { get; set; }
        public string ChequeNo { get; set; }
        public decimal ChequeAmount { get; set; }
        public string Note { get; set; }
        public List<DisbursedIntallments> Installments { get; set; }
    }
    public class DisbursedIntallments
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
