using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Helpers.Extensions
{
    public static class NepaliDateExtension
    {
        public static DateTime ConvertoNepaliDate(this string nepDate)
        {
            try {
                int.TryParse(nepDate.Split('-')[0].ToString(), out int year);
                int.TryParse(nepDate.Split('-')[1].ToString(), out int month);
                int.TryParse(nepDate.Split('-')[2].ToString(), out int day);
               return NepaliDateConveter.Convert2EnglishDate.GetDate(year, month, day);
            }
            catch
            {
                return new DateTime();
            }
        }
    }
}
