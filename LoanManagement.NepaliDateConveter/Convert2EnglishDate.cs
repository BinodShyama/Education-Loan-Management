using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.NepaliDateConveter
{

    public static class Convert2EnglishDate
    {

        public static DateTime GetDate( int npYear, int npMonth, int npDay)
        {
            try
            {
                var days = 0;
                var initday = 0;
                var i = 0;
                var dt = new DateTime();
                switch (npMonth)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        {
                            days = 0;
                            for (i = 3; i < 5 + npMonth; i++)
                            {
                                days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[i];
                            }
                            days += npDay > NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[i] ? NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[i] : npDay;
                            days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[2] - NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[1];
                            dt = new DateTime(npYear - 57, 1, 1);
                            dt = dt.AddDays(days);
                            break;
                        }
                    case 9:
                        {
                            initday = NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[1];
                            npDay = npDay > NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[14] ? NepaliDateDataArray.GetNepaliDateDataArray(npYear - 57)[14] : npDay;
                            if (npDay < initday)
                            {
                                for (i = 3; i < 14; i++)
                                {
                                    days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[i];
                                }
                                days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[2] - NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[1];
                                days += npDay - 1;
                                dt = new DateTime(npYear - 57, 1, 1);
                            }
                            else
                            {
                                days += npDay - initday;
                                dt = new DateTime(npYear - 56, 1, 1);
                            }
                            dt = dt.AddDays(days);
                            break;
                        }
                    case 10:
                    case 11:
                    case 12:
                        {
                            for (i = 3; i < npMonth - 7; i++)
                            {
                                days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[i];
                            }
                            days += NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[2] - NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[1];
                            days += npDay > NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[i] ? NepaliDateDataArray.GetNepaliDateDataArray(npYear - 56)[i] : npDay;//npDay;
                            dt = new DateTime(npYear - 56, 1, 1);
                            dt = dt.AddDays(days);
                            break;
                        }
                }
                return dt;
            }catch(Exception ex)
            {
                throw new NullReferenceException();
            }
        }
    }

}
