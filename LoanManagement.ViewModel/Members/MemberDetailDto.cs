using LoanManagement.ViewModel.DataAnnotationValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagement.ViewModel.Members
{
    public class MemberDetailDto
    {
        public string Id { get; set; }
        public int MemberId { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [MaxLength(50, ErrorMessage = "First Name cannot be greater than 50")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(50, ErrorMessage = "Last Name cannot be greater than 50")]
        public string LastName { get; set; }
        public string NationalIdentiryCardNumber { get; set; }
        [Required(ErrorMessage = "Gender is required.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Date of Birth is required.")]
        [NepaliDateValidation(ErrorMessage = "Date of birth is not valid date.")]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[02])$",ErrorMessage ="Invalid date format.")]
        public string BirthofDateBS { get; set; }
        public DateTime BirthOfDateAD { get; set; }
        public string Nationality { get; set; } = "Nepali";
        [Required(ErrorMessage = "Citizenship no. is required.")]
        [MinLength(3, ErrorMessage = "Citizenship no. should be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Citizenship no. should be less than 50 characters.")]
        public string CitizenShipNumber { get; set; }
        [Required(ErrorMessage = "Citizenship issued date is required.")]
        [NepaliDateValidation(ErrorMessage = "Citizenship issued date is not valid date.")]
        [RegularExpression("^\\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\\d)|3[02])$", ErrorMessage = "Invalid date format.")]
        public string CitizenIssuedDateBS { get; set; }
        public DateTime CitizenIssuedDateAD { get; set; }
        [Required(ErrorMessage = "Citizenship issued district is required.")]
        public string CitizenIssuedDistrict { get; set; }
        [Required(ErrorMessage = "Mobile no. is required.")]
        [MinLength(5, ErrorMessage = "Mobile no. should be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Mobile no. should be less than 50 characters.")]
        public string MobileNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Parmanent state is required.")]
        public string PermanentState { get; set; } = "3";
        [Required(ErrorMessage = "Parmanent district is required.")]
        public string PermanentDistrict { get; set; }
        [Required(ErrorMessage = "Parmanent municipality is required.")]
        public string PermanentMunicipality { get; set; } = "Bhaktapur";
        [Required(ErrorMessage = "Parmanent ward no. is required.")]

        [MaxLength(2, ErrorMessage = "Ward no. should be less than 2 characters.")]
        public string PermanentWardNumber { get; set; }
        [Required(ErrorMessage = "Parmanent street is required.")]
        [MaxLength(256, ErrorMessage = "Street should be less than 256 characters.")]
        public string PermanentStreet { get; set; }
        [MaxLength(10, ErrorMessage = "House no. should be less than 10 characters.")]
        public string ParmanentHouseNo { get; set; }

        [Required(ErrorMessage = "Temporary state is required.")]
        public string TemporaryState { get; set; }
        [Required(ErrorMessage = "Temporary district is required.")]
        public string TemporaryDistrict { get; set; }
        [Required(ErrorMessage = "Temporary municipality is required.")]
        public string TemporaryMunicipality { get; set; } = "Bhaktapur";
        [Required(ErrorMessage = "Temporary ward no. is required.")]
        [MaxLength(2, ErrorMessage = "Ward no. should be less than 2 characters.")]
        public string TemporaryWardNumber { get; set; }

        [MaxLength(10, ErrorMessage = "House no. should be less than 10 characters.")]
        public string TemporaryHouseNo { get; set; }

        [Required(ErrorMessage = "Temporary street. is required.")]

        [MaxLength(256, ErrorMessage = "Street should be less than 256 characters.")]
        public string TemporaryStreet { get; set; }
        [Required(ErrorMessage = "Father's name is required.")]

        [MaxLength(100, ErrorMessage = "Father name should be less than 100 characters.")]
        public string FatherFullName { get; set; }
        [Required(ErrorMessage = "Mother's name is required.")]
        [MaxLength(100, ErrorMessage = "Mother name should be less than 100 characters.")]
        public string MotherFullName { get; set; }
        [Required(ErrorMessage = "Grandfather's name is required.")]
        [MaxLength(100, ErrorMessage = "Grandfather name should be less than 100 characters.")]
        public string GrandFatherFullName { get; set; }
        [MaxLength(100, ErrorMessage = "Spouse name should be less than 100 characters.")]
        public string SpouseFullName { get; set; }

        //[Required(ErrorMessage = "Name is required.")]
        //[MaxLength(100, ErrorMessage = "Name should be less than 100 characters.")]
        //public string LoanGuarantorFullName { get; set; }
        //[Required(ErrorMessage = "Relationship is required.")]
        //public string LoanGuarantorRelationship { get; set; }
        //[Required(ErrorMessage = "Contact no. is required.")]
        //[MaxLength(50, ErrorMessage = "Contact no. should be less than 50 characters.")]
        //public string LoanGuarantorContactNo { get; set; }
        //[Required(ErrorMessage = "Citizenship no. is required.")]
        //public string LoanGuarantorCitizenshipNo { get; set; }
        //[Required(ErrorMessage = "Citizenship issue district is required.")]
        //public string LoanGuarantorCitizenshipIssueDistrict { get; set; }
    }
}
