using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Contracts
{
   public class ContractDto
    {
        public int Id { get; set; }
        public string DateNep { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal LoanAmount { get; set; }
        public int LoanDuration { get; set; }
        public string CollegeName { get; set; }
        public string Degree { get; set; }
        public decimal InstallmentFirst { get; set; }
        public decimal InstallmentSecond { get; set; }
        public decimal InstallmentThird { get; set; }
    }
}
