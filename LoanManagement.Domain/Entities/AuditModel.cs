using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
  public abstract  class AuditModel
    {
        public bool Status { get; set; }
        [Column(TypeName ="varchar(50)")]
        public string CreatedBy { get; set; }
        [Column(TypeName ="datetime2(3)")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string UpdatedBy { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime UpdateDate { get; set; }
    }
}
