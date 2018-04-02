using System;
using System.Linq;

namespace DefiningClasses_Exercise3
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var person = new Person()
                {
                    name = input[0],
                    age = int.Parse(input[1])
                };

                family.AddMemeber(person);
            }

            var oldestMembers = family.GetMembersOverThirty();
            foreach (var member in oldestMembers.OrderBy(m => m.name))
            {
                Console.WriteLine($"{member.name} - {member.age}");
            }
        }
    }
}