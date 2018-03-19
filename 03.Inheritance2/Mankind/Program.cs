using System;

public class Program
{
    public static void Main()
    {
        try
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var studentFirstName = input[0];
            var studentLastName = input[1];
            var facultyNumber = input[2];
            var student = new Student(studentFirstName, studentLastName, facultyNumber);

            input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var workerFirstName = input[0];
            var workerLastName = input[1];
            var salary = decimal.Parse(input[2]);
            var workingHours = decimal.Parse(input[3]);
            var worker = new Worker(workerFirstName, workerLastName, salary, workingHours);

            Console.WriteLine(student.ToString());
            Console.WriteLine(worker.ToString());
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}