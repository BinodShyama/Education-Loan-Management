using LoanManagement.ViewModel.DataAnnotationValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.Cheque
{
    public class ChequeDataDto
    {
        [Required]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[02])$", ErrorMessage = "Invalid date format.")]
        [NepaliDateValidation(ErrorMessage = "Invalid date format.")]
        public string Date { get; set; }
        [Required]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }
        [Required]
        public string Payee { get; set; }
        public string AmountInWord { get; set; }
    }
}
