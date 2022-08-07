using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class ChequeMedia:AuditModel
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("ChequeLayout")]
        public string LayoutId { get; set; }
        [ForeignKey("Media")]
        public string MediaId { get; set; }
        public virtual ChequeLayout ChequeLayout { get; set; }
        public virtual Media Media { get; set; }
    }
}
