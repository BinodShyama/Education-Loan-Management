using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Members
{
  public  class MemberSummaryViewDto
    {
        public string Id { get; set; }
        public string MemberId { get; set; }
        public string Name { get; set; }
        public string BirthofDateBS { get; set; }
        public string NationalIdentiryCardNumber { get; set; }
        public string CitizenShipNumber { get; set; }
        public string Address { get; set; }
        public  string  SanctionAmount { get; set; }
        public string MaturityDate { get; set; }
        public string ContactNo { get; set; }
        public string LoanId { get; set; }
        public List<InstallmentdDetail> Installments { get; set; } = new List<InstallmentdDetail>();
        public List<TransactionDetail> TransactionDetail { get; set; } = new List<TransactionDetail>();
    }

    public class TransactionDetail {
        public string VoucherDate { get; set; }
        public string Particulars { get; set; }
        public decimal DrAmount { get; set; }
        public decimal CrAmount { get; set; }
    }

    public class InstallmentdDetail
    {
        public string InstallmentId { get; set; }
        public string Installment { get; set; }
        public string Amount { get; set; }
        public bool Disbrused { get; set; }
    }

}
