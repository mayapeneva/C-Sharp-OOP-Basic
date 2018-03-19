using System;

public class AnimalFactory
{
    public Animal CreateAnimal(string type, string name, int age, string gender)
    {
        switch (type)
        {
            case "Cat":
                return new Cat(name, age, gender);

            case "Dog":
                return new Dog(name, age, gender);

            case "Frog":
                return new Frog(name, age, gender);

            case "Kitten":
                return new Kitten(name, age);

            case "Tomcat":
                return new Tomcat(name, age);
        }

        throw new ArgumentException("Invalid input!");
    }
}