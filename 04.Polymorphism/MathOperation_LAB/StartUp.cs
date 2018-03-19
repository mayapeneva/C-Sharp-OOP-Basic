using System;

class Program
{
    public static void Main()
    {
        var operation = new MathOperations();
        Console.WriteLine(operation.Add(2, 3));
        Console.WriteLine(operation.Add(2.2, 3.3, 5.5));
        Console.WriteLine(operation.Add(2.2m, 3.3m, 4.4m));
    }
}