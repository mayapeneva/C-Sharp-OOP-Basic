using System;

namespace MordorsCrueltyPlan_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var factory = new FoodFactory();
            foreach (var food in input)
            {
                factory.GetFed(food);
            }

            var mood = new MoodFactory();
            Console.WriteLine(mood.GetFinalMood(factory.GetMood()));
        }
    }
}