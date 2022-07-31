using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanManagement.Domain.Entities
{
    public class User : IdentityUser<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        public bool Status { get; set; }
        public string FirstName { get; set; }
        public string Type { get; set; }
        public bool IsAdmin { get; set; } = false;
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }= new DateTime();
        public DateTime LastActive { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
