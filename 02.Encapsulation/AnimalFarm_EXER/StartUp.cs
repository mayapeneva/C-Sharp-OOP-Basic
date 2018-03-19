using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace AnimalFarm_EXER
{
    public class StartUp
    {
        public static void Main()
        {
            var chickenType = typeof(Chicken);
            var fields = chickenType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var methods = chickenType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(fields.Where(f => f.IsPrivate).Count() == 2);
            Debug.Assert(methods.Where(m => m.IsPrivate).Count() == 1);

            try
            {
                var name = Console.ReadLine();
                var age = int.Parse(Console.ReadLine());

                var chicken = new Chicken(name, age);
                Console.WriteLine($"Chicken {chicken.Name} (age {chicken.Age}) can produce {chicken.GetProductPerDay()} eggs per day.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
