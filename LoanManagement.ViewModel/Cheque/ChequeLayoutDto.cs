using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Cheque
{
    public class ChequeLayoutDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Width { get; set; } = 20;
        public double Height { get; set; } = 9;
        public double XDate { get; set; } = 14;
        public double YDate { get; set; } = 1.5;
        public double XAmount { get; set; } = 14;
        public double YAmount { get; set; } = 3.8;
        public double XPayee { get; set; } = 4;
        public double YPayee { get; set; } = 2.5;
        public double XAmountInWordLine1 { get; set; } = 2;
        public double YAmountInWordLine1 { get; set; } = 3;
        public double XAmountInWordLine2 { get; set; }=.5;
        public double YAmountInWordLine2 { get; set; } = 3.8;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
