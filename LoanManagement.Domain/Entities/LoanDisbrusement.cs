using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
    public class LoanDisbrusement : AuditModel
    {
        [Key]
        public string Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VoucherDateNep { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime VoucherDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VoucherNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LoanAc { get; set; }
        public string MemberId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string BankName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ChequeDate { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ChequeNo { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ChequeAmount { get; set; }
        public int TransactionId { get; set; }
        public string Note { get; set; }

        public string MemberLoanDetailId { get; set; }
        [ForeignKey("MemberLoanDetailId")]
        public virtual MemberLoanDetail MemberLoanDetail { get; set; }
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
        public virtual IEnumerable<LoanDisbrusementDetail> LoanDisbrusementDetail { get; set; }
    }
}
