using System;

namespace FamilyTree_Exercise
{
    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public Person(DateTime birthday)
        {
            this.Birthdate = birthday;
        }

        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
}