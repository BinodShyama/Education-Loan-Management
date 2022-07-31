using LoanManagement.ViewModel.DataAnnotationValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.LoanCollections
{
   public class LoanCollectionCreateDto
    {
        public string Id { get; set; }
        public string LoanAc { get; set; }
        [Required(ErrorMessage = "Please select a member.")]
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        [Required(ErrorMessage = "Voucher date is required.")]
        [NepaliDateValidation(ErrorMessage = "Voucher date is not valid date.")]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[02])$", ErrorMessage = "Invalid date format.")]
        public string VoucherDate { get; set; }
       
        public decimal InterestAmount { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal PenaltyAmount { get; set; }
        [Required(ErrorMessage = "Pelase enter amount to collect.")]
        [Range(1, int.MaxValue, ErrorMessage = "Pelase enter amount to collect.")]
        public decimal Amount { get; set; }
        public bool IsBank { get; set; }
        //[Required(ErrorMessage = "Bank name is required.")]
        //[MaxLength(500, ErrorMessage = "Bank name cannot be greater than 500")]
        public string BankName { get; set; }
        //[Required(ErrorMessage = "Cheque date is required.")]
        public string ChequeDate { get; set; }
        //[Required(ErrorMessage = "Cheque no. is required")]
        //[MaxLength(50, ErrorMessage = "Cheque no. cannot be greater than 50")]
        public string ChequeNo { get; set; }
        public decimal ChequeAmount { get; set; }
        public string Note { get; set; }
    }
}
