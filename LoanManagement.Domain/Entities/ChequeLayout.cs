using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class ChequeLayout:AuditModel
    {
        [Key]
        public string Id { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Name { get; set; }
        public double Width { get; set; } = 20;
        public double Height { get; set; } = 9;
        public double XDate { get; set; } = 14;
        public double YDate { get; set; } = 1.5;
        public double XAmount { get; set; } = 14;
        public double YAmount { get; set; } = 3.8;
        public double XPayee { get; set; } = 4;
        public double YPayee { get; set; } = 2.5;
        public double XAmountInWordLine1 { get; set; } = 2;
        public double YAmountInWordLine1 { get; set; } = 3;
        public double XAmountInWordLine2 { get; set; } = .5;
        public double YAmountInWordLine2 { get; set; } = 3.8;
    }
}
