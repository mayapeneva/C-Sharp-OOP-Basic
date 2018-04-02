using System.Collections.Generic;

namespace Google_Exercise
{
    public class Person
    {
        public string name;
        public Company company;
        public List<Pokemon> pokemons;
        public List<Parent> parents;
        public List<Child> children;
        public Car car;

        public Person(string name)
        {
            this.name = name;
            this.company = new Company();
            this.pokemons = new List<Pokemon>();
            this.parents = new List<Parent>();
            this.children = new List<Child>();
            this.car = new Car();
        }
    }
}