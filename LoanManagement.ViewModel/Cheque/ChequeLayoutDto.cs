using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.Cheque
{
    public class ChequeLayoutDto
    {
        public string Id { get; set; }
        [Required]
        [Remote(action: "ChequeValiation", controller: "ChequeLayout", ErrorMessage = "Layout Name Already Exists.", HttpMethod = "Post",AdditionalFields ="Id")]
        public string Name { get; set; }
        [Required]
        public double Width { get; set; } = 20;
        [Required]
        public double Height { get; set; } = 9;
        [Required]
        public double XDate { get; set; } = 14;
        [Required]
        public double YDate { get; set; } = 1.5;
        [Required]
        public double XAmount { get; set; } = 14;
        [Required]
        public double YAmount { get; set; } = 3.8;
        [Required]
        public double XPayee { get; set; } = 4;
        [Required]
        public double YPayee { get; set; } = 2.5;
        [Required]
        public double XAmountInWordLine1 { get; set; } = 2;
        [Required]
        public double YAmountInWordLine1 { get; set; } = 3;
        [Required]
        public double XAmountInWordLine2 { get; set; }=.5;
        [Required]
        public double YAmountInWordLine2 { get; set; } = 3.8;
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
