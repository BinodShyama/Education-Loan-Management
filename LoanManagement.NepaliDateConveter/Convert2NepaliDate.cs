using System;
using System.Collections.Generic;
using System.Text;

namespace LoanManagement.NepaliDateConveter
{
    public sealed class Convert2NepaliDate
    {
        private Convert2NepaliDate()
        {
        }
        /// <summary>
        ///         ''' Main Algorithm to Convert English date to Nepali date
        ///         ''' </summary>
        ///         ''' <param name="enDate">English date to get converted</param>
        ///         ''' <returns>NepaliDate object with actual Nepali date info</returns>
        public static NepaliDate GetNepaliDate(DateTime enDate)
        {
            // #Region "Core Algorithm for Nepali date conversion"
            // Getting Nepali date data for Nepali date calculation
            int[] npDateData = NepaliDateDataArray.GetNepaliDateDataArray(enDate.Year);

            // Getting English day of the year
            int enDayOfYear = enDate.DayOfYear;

            // Initializing Nepali Year from the data
            int npYear = npDateData[0];

            // Initializing Nepali month to Poush (9)
            // This is because English date Jan 1 always fall in Poush month of Nepali Calendar, which is 9th month of Nepali calendar
            int npMonth = 9;

            // Initializing Nepali DaysInMonth with total days in the month of Poush
            int npDaysInMonth = npDateData[2];

            // Initializing temp nepali days
            // This is sum of total days in each Nepali month starting Jan 1 in Nepali month Poush
            // Note: for the month Poush, only counting days after Jan 1
            // ***** This is the key field to calculate Nepali date *****
            int npTempDays = npDateData[2] - npDateData[1] + 1;

            // Looping through Nepali date data array to get exact Nepali month, Nepali year & Nepali daysInMonth information
            int i = 3;
            while (enDayOfYear > npTempDays)
            {
                npTempDays += npDateData[i];
                npDaysInMonth = npDateData[i];
                npMonth += 1;

                if (npMonth > 12)
                {
                    npMonth -= 12;
                    npYear += 1;
                }
                i += 1;
            }

            // Calculating Nepali day
            int npDay = npDaysInMonth - (npTempDays - enDayOfYear);
            // #End Region
            // npDay.ToString("00")
            // #Region "Constructing and returning NepaliDate object"
            // Returning back NepaliDate object with all the date details
            NepaliDate npDate = new NepaliDate();
            npDate.npDate = String.Format("{0}/{1}/{2}", npYear, npMonth.ToString("00"), npDay.ToString("00"));
            npDate.npYear = npYear;
            npDate.npMonth = npMonth;
            npDate.npDay = npDay;
            npDate.npDaysInMonth = npDaysInMonth;

            return npDate;
        }
    }
}
