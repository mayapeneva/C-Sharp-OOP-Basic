using System;

public class Program
{
    public static void Main()
    {
        var mood = 0;

        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var food in input)
        {
            Foods en;
            var IfParsed = Enum.TryParse(food, true, out en);
            if (IfParsed)
            {
                mood += (int)en;
            }
            else
            {
                mood -= 1;
            }
        }

        Console.WriteLine(mood);

        var result = string.Empty;
        if (mood < -5)
        {
            result = "Angry";
        }
        else if (mood >= -5 && mood <= 0)
        {
            result = "Sad";
        }
        else if (mood > 0 && mood <= 15)
        {
            result = "Happy";
        }
        else
        {
            result = "JavaScript";
        }
        Console.WriteLine(result);
    }
}