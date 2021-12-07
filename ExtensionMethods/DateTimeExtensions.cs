using System;

namespace GitGoodScrub
{
    public static class DateTimeExtensions
    {   
        public static int DaysToNextDayOfWeek(this DateTime date, DayOfWeek to) 
        {   
            int diff = (to - date.DayOfWeek);

            if (diff < 0) return 7 - Math.Abs(diff); //or perhaps (7 + diff)

            return diff;
        }

        public static bool IsBetween(this DateTime date, DateTime start, DateTime end) 
        {
            return (date>=start && date<=end);
        }
    }
}