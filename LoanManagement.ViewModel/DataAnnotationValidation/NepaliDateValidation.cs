using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanManagement.ViewModel.DataAnnotationValidation
{
    public class NepaliDateValidationAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-nepaliDateValidation", ErrorMessage);
        }
        private bool MergeAttribute(IDictionary<string, string> attributes, string key, string value)
        {
            if (attributes.ContainsKey(key))
            {
                return false;
            }
            attributes.Add(key, value);
            return true;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                int.TryParse(value.ToString().Split("-")[0].ToString(), out int year);
                int.TryParse(value.ToString().Split("-")[1].ToString(), out int month);
                int.TryParse(value.ToString().Split("-")[2].ToString(), out int day);
                NepaliDateConveter.Convert2EnglishDate.GetDate(year, month, day);
                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult(ErrorMessage??"Invalid date.");
            }
        }
    }
}
