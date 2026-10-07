namespace DateTimeCheckerLib
{
    public class DateTimeChecker
    {
        /// <summary>
        /// Calculates the number of days in a specific month and year according to the Gregorian calendar.
        /// </summary>
        /// <param name="month">Month (1 to 12)</param>
        /// <param name="year">Year (positive integer)</param>
        /// <returns>Number of days in month (28, 29, 30, 31), or 0 if month is invalid.</returns>
        public static int DayInMonth(int month, int year)
        {
            if (month < 1 || month > 12)
            {
                return 0;
            }

            switch (month)
            {
                case 1:  // January
                case 3:  // March
                case 5:  // May
                case 7:  // July
                case 8:  // August
                case 10: // October
                case 12: // December
                    return 31;

                case 4:  // April
                case 6:  // June
                case 9:  // September
                case 11: // November
                    return 30;

                case 2:  // February
                    return IsLeapYear(year) ? 29 : 28;

                default:
                    return 0;
            }
        }

        /// <summary>
        /// Alias for DayInMonth to match Function Name 'DaysInMonth' in Excel specification.
        /// </summary>
        public static int DaysInMonth(int month, int year)
        {
            return DayInMonth(month, year);
        }

        /// <summary>
        /// Checks whether a given day, month, and year form a valid date in the Gregorian calendar.
        /// </summary>
        /// <param name="day">Day of month</param>
        /// <param name="month">Month of year</param>
        /// <param name="year">Year</param>
        /// <returns>True if valid date; False otherwise.</returns>
        public static bool CheckDate(int day, int month, int year)
        {
            if (month < 1 || month > 12)
            {
                return false;
            }

            if (day < 1)
            {
                return false;
            }

            int daysInCurrentMonth = DayInMonth(month, year);
            return day <= daysInCurrentMonth;
        }

        /// <summary>
        /// Alias for CheckDate to match Function Name 'IsValidDate' in Excel specification.
        /// </summary>
        public static bool IsValidDate(int day, int month, int year)
        {
            return CheckDate(day, month, year);
        }

        /// <summary>
        /// Determines whether a specified year is a leap year in the Gregorian calendar.
        /// Rule: Year divisible by 400 OR (divisible by 4 AND NOT divisible by 100).
        /// </summary>
        /// <param name="year">Year to check</param>
        /// <returns>True if leap year, False otherwise.</returns>
        public static bool IsLeapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            if (year % 100 == 0)
            {
                return false;
            }
            return year % 4 == 0;
        }
    }
}
