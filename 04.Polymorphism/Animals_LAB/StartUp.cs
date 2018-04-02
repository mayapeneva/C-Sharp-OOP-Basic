using System;

internal class StartUp
{
    public static void Main()
    {
        Animal dog = new Dog("Pesho", "Whiskas");
        Animal cat = new Cat("Gosho", "Meat");

        Console.WriteLine(cat.ExplainMyself());
        Console.WriteLine(dog.ExplainMyself());
    }
}