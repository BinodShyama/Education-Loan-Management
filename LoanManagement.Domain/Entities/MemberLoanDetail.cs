using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
    public class MemberLoanDetail: AuditModel
    {
        [Key]
        public string Id { get; set; }

        public string LoanAccountNo { get; set; }

        public int SerialNo { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string LoanGuarantorName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LoanGuarantorRelationship { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LoanGuarantorContactNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LoanGuarantorCitizenshipNo { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string LoanGuarantorCitizenshipIssueDistrict { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Degree { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Institution { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string University { get; set; }
        [Column(TypeName = "nvarchar(256)")]
        public string Country { get; set; }
        [Column(TypeName = "decimal(3,2)")]
        public decimal Duration { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DateOfCommencementNep { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime DateOfCommencement { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LoanAmount { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LoanMaturityDateNep { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime LoanMaturityDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Installment1 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Installment2 { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Installment3 { get; set; }

        [ForeignKey("Member")]
        public string MemberId { get; set; }

        public virtual IEnumerable<MemberLoanInstallment> Installments { get; set; }
    }
}
