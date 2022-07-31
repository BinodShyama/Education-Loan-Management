using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class LoanCollectionDetail:AuditModel
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("LoanCollection")]
        public string LoanCollectionId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string VoucherNo { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public virtual LoanCollection LoanCollection { get; set; }
    }
}
