using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class Districts
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey("ProvinceId")]
        public virtual Provinces Province { get; set; }

        public virtual Municipalities Municipality { get; set; }
    }
}
