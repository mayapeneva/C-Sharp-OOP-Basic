using System;
using System.Runtime.InteropServices;

public class DateModifier
{
    private int difference;

    public int CalculateDifference(string date1, string date2)
    {
        var firstDate = DateTime.Parse(date1);
        var secondDate = DateTime.Parse(date2);
        this.difference = (int)Math.Abs((secondDate - firstDate).TotalDays);

        return this.difference;
    }
}