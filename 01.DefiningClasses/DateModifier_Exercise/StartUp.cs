using System;

namespace DateModifier_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var startDate = Console.ReadLine();
            var endDate = Console.ReadLine();

            var result = new DateModifier(startDate, endDate).GetDifferenceInTime();
            Console.WriteLine(result);
        }
    }
}