using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses_Exercise3
{
    public class Family
    {
        public List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMemeber(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            var maxAge = people.Select(p => p.age).Max();
            return people.First(p => p.age == maxAge);
        }

        public List<Person> GetMembersOverThirty()
        {
            return people.Where(p => p.age > 30).ToList();
        }
    }
}