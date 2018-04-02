using System;

namespace Mankind_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                var studentInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var workerInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var student = new Student(studentInfo[0], studentInfo[1], studentInfo[2]);
                var worker = new Worker(workerInfo[0], workerInfo[1], double.Parse(workerInfo[2]), double.Parse(workerInfo[3]));

                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Faculty number: {student.FacultyNumber}");
                Console.WriteLine();
                Console.WriteLine($"First Name: {worker.FirstName}");
                Console.WriteLine($"Last Name: {worker.LastName}");
                Console.WriteLine($"Week Salary: {worker.WeekSalary:f2}");
                Console.WriteLine($"Hours per day: {worker.WorkingHoursPerDay:f2}");
                Console.WriteLine($"Salary per hour: {worker.CalculateSalaryPerHour():f2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}