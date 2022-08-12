using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrehPL.Tools.Extensions.CalendarExtensions
{
    public class CalendarExtensionTool
    {
        public static int GetWeekNumber(DateTime dateTime)
        {
            CultureInfo myCI = new CultureInfo("pl-PL");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int weekOfYear = myCal.GetWeekOfYear(dateTime, myCWR, myFirstDOW);
            return weekOfYear;
        }

        public static DateTime GetFirstDayOfWeek(int weekNumber)
        {
            DateTime dateTime = DateTime.Now;
            bool run = true;
            if (weekNumber <= GetWeekNumber(DateTime.Now))
            {
                while (run)
                {
                    dateTime = dateTime.AddDays(-1);
                    int newWeekNumber = GetWeekNumber(dateTime);
                    if (weekNumber > newWeekNumber)
                    {
                        dateTime = dateTime.AddDays(1);
                        run = false;
                    }
                }
            }
            else
            {
                while (run)
                {
                    dateTime = dateTime.AddDays(1);
                    int newWeekNumber = GetWeekNumber(dateTime);
                    if (weekNumber == newWeekNumber)
                    {
                        run = false;
                    }
                }
            }
            return dateTime;
        }
    }
}
