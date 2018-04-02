namespace DefiningClasses_Exercise
{
    public class Person
    {
        public string name;

        public int age;

        public Person()
        {
            name = "No name";
            age = 1;
        }

        public Person(int age)
            : this()
        {
            this.age = age;
        }

        public Person(string name, int age)
            : this(age)
        {
            this.name = name;
        }
    }
}