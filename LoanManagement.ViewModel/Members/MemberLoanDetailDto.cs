using LoanManagement.ViewModel.DataAnnotationValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.Members
{
    public class MemberLoanDetailDto
    {
        public string Id { get; set; }

        public string LoanAccountNo { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(256, ErrorMessage = "First Name cannot be greater than 256")]
        public string LoanGuarantorName { get; set; }
        [Required(ErrorMessage = "Relationship is required.")]
        public string LoanGuarantorRelationship { get; set; }
        [Required(ErrorMessage = "Contact no. is required.")]
        [MaxLength(50, ErrorMessage = "Contact no. cannot be greater than 50")]

        public string LoanGuarantorContactNo { get; set; }
        [Required(ErrorMessage = "Citizenship no.  is required.")]
        [MaxLength(50, ErrorMessage = "Citizenship no.   cannot be greater than 50")]
        public string LoanGuarantorCitizenshipNo { get; set; }
        [Required(ErrorMessage = "Citizenship issue district is required.")]
        [MaxLength(256)]
        public string LoanGuarantorCitizenshipIssueDistrict { get; set; }
        [Required]
        [MaxLength(256)]

        public string Degree { get; set; }
        [Required]
        [MaxLength(256)]
        public string Institution { get; set; }

        [MaxLength(256, ErrorMessage = "University cannot be greater than 256")]
        public string University { get; set; }
        [MaxLength(256, ErrorMessage = "Country name cannot be greater than 256")]
        public string Country { get; set; }
        [Range(0, 9.99)]
        //[MaxLength(4)]
        public decimal Duration { get; set; }
        [Required(ErrorMessage ="Date of commecement is required.")]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[02])$", ErrorMessage = "Invalid date format.")]
        [NepaliDateValidation(ErrorMessage = "Invalid date format.")]
        public string DateOfCommencementNep { get; set; }
        public DateTime DateOfCommencement { get; set; }

        public string LoanMaturityDateNep { get; set; }
        public DateTime LoanMaturityDate { get; set; }
        [Range(1, 1000000)]
        //[MaxLength(7)] 
        public decimal LoanAmount { get; set; }
        [Range(1, 500000)]
        //[MaxLength(6)]
        public decimal Installment1 { get; set; }
        [Range(1, 500000)]
        //[MaxLength(6)]
        public decimal Installment2 { get; set; }
        [Range(1, 500000)]
        //[MaxLength(6)]
        public decimal Installment3 { get; set; }
        public string MemberId { get; set; }
    }
}
