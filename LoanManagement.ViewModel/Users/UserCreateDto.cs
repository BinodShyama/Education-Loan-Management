using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.Users
{
   public class UserCreateDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } = new DateTime();
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public virtual bool Status { get; set; } = true;

        [Required(ErrorMessage = "Please Enter First Name.")]
        [Display(Name = "Full Name")]
        //[StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [RegularExpression(@"^[a-zA-Z_ ]*$", ErrorMessage = "Allowed characters are A-Z, a-z and _")]
        [Required(ErrorMessage = "Please Enter User Name.")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Remote(action: "CheckDuplicateUserName", controller: "UserValidation", ErrorMessage = "Uer Name Already Exists.", HttpMethod = "Post", AdditionalFields = "Id")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email Address is required.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email")]
        [StringLength(40, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Remote(action: "CheckDuplicateEmail", controller: "UserValidation", ErrorMessage = "Email Address Already Exists.", HttpMethod = "Post", AdditionalFields = "Id")]
        [EmailAddress(ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }


        [RegularExpression(@"(?=^.{8,20}$)(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?!.*\s).*$", ErrorMessage = "Password should have A-Z, a-z, 0-9 and some special characters #,!,@ etc..")]
        [Required(ErrorMessage = "Please Enter Password.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}
