using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.ViewModel.Members
{
    public class MemberListDto
    {
        public string Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BirthofDateBS { get; set; }
        public string NationalIdentiryCardNumber { get; set; }
        public string CitizenShipNumber { get; set; }
        public string CitizenIssuedDateBS { get; set; }
        public string MobileNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Tole { get; set; }
        public string WardNumber { get; set; }
        public string HouseNo { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string GrandFatherName { get; set; }
        public decimal SanctionAmount { get; set; }
        public string SanctionAmountStr { get; set; }
        public string Degree { get; set; }
        public string Institution { get; set; }
        public string University { get; set; }

    }
}
