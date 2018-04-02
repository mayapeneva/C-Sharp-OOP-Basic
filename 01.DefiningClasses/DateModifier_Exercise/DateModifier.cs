using System;
using System.Globalization;

namespace DateModifier_Exercise
{
    public class DateModifier
    {
        public DateTime startDate;

        public DateTime endDate;

        public DateModifier(string startDate, string endDate)
        {
            this.startDate = DateTime.ParseExact(startDate, "yyyy MM dd", CultureInfo.InvariantCulture);

            this.endDate = DateTime.ParseExact(endDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        }

        public double GetDifferenceInTime()
        {
            return Math.Abs(endDate.Subtract(startDate).TotalDays);
        }
    }
}