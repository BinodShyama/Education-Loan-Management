using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Users
{
    public class UserListDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
        public string Action { get; set; }
    }
}
