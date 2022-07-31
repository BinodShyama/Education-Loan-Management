using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
    public class Transaction:AuditModel
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Member")]
        public string MemberId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VoucherNo { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VoucherDateNep { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime VoucherDate { get; set; }
        public string Particular { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Note { get; set; }
        public int VoucherIndex { get; set; }
        public virtual IEnumerable<TransactionDetail> TransactionDetail { get; set; }
        public string FisicalYearId { get; set; }
    }
}
