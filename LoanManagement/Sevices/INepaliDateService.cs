using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Sevices
{
    public interface INepaliDateService
    {
        string GetCurrentNepaliDate();
    }
    public class NepaliDateService : INepaliDateService
    {
        public string GetCurrentNepaliDate()
        {
            try
            {
                var nDate = NepaliDateConveter.Convert2NepaliDate.GetNepaliDate(DateTime.Now);
                return $"{nDate.npYear.ToString("0000")}-{nDate.npMonth.ToString("00")}-{nDate.npDay.ToString("00")}";
            }
            catch(Exception ex)
            {
                return "";
            }
        }
    }
}
