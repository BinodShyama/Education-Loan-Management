using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
    public class MemberLoanInstallment : AuditModel
    {
        [Key]
        public string Id { get; set; }
        public string LoanAcNo { get; set; }
        public int InstallmentNo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [ForeignKey("MemberLoanDetail")]
        public string MemberLoanDetailId { get; set; }
        public bool Disbrused { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime? DisbrusedDate { get; set; }
    }
}
