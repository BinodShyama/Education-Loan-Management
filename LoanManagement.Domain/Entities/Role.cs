using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LoanManagement.Domain.Entities
{
    public class Role: IdentityRole<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string Identifier { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = new DateTime();
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<RolePermission> RolePermission { get; set; }

    }
}
