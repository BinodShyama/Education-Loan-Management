using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
    public class TransactionDetail : AuditModel
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("Transaction")]
        public string TransactionId { get; set; }
        public string Particular { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal DrAmount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal CrAmount { get; set; }
        public string Note { get; set; }
        public int Order { get; set; }
        public string FisicalYearId { get; set; }
    }
}
