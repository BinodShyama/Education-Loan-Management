using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
  public  class Media:AuditModel
    {
        [Key]
        public string Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Url { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Type { get; set; }
        public string Path { get; set; }
    }
}
