using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class Municipalities
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrinctId { get; set; }
        [ForeignKey("DistrinctId")]
        public virtual Districts District { get; set; }
    }
}
