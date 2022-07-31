using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanManagement.Domain.Entities
{
   public class Member: AuditModel
    {
        [Key]
        public string Id { get; set; }
        public int? CustomMemberId { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string MiddleName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string NationalIdentiryCardNumber { get; set; }
        [Column(TypeName="nvarchar(20)")]
        public string Gender { get; set; }
        [Column(TypeName="nvarchar(20)")]
        public string BirthofDateBS { get; set; }
        [Column(TypeName = "datetime2(3)")]
        public DateTime BirthOfDateAD { get; set; }
        public string Nationality { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string CitizenShipNumber { get; set; }
        [Column(TypeName="nvarchar(20)")]
        public string CitizenIssuedDateBS { get; set; }

        [Column(TypeName ="datetime2(3)")]
        public DateTime CitizenIssuedDateAD { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string CitizenIssuedDistrict { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string MobileNumber { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string Email { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string Country { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string PermanentState { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string PermanentDistrict { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string PermanentMunicipality { get; set; }
        [Column(TypeName="nvarchar(2)")]
        public string PermanentWardNumber { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string PermanentStreet { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PermanentHouseNo { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string TemporaryState { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string TemporaryDistrict { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string TemporaryMunicipality { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string TemporaryWardNumber { get; set; }
        [Column(TypeName="nvarchar(50)")]
        public string TemporaryStreet { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string TemporaryHouseNo { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string FatherFullName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string MotherFullName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string GrandFatherFullName { get; set; }
        [Column(TypeName="nvarchar(100)")]
        public string SpouseFullName { get; set; }
        public virtual MemberLoanDetail MemberLoan { get; set; }

        //[Column(TypeName = "nvarchar(100)")]
        //public string LoanGuarantorFullName { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        //public string LoanGuarantorRelationship { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        //public string LoanGuarantorContactNo { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        //public string LoanGuarantorCitizenshipNo { get; set; }
        //[Column(TypeName = "nvarchar(50)")]
        //public string LoanGuarantorCitizenshipIssueDistrict { get; set; }

    }
}
