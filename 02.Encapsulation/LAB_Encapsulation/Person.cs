using System;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private double salary;

    public Person(string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public Person(string firstName, string lastName, int age, double salary)
        : this(firstName, lastName, age)
    {
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot be less than 3 symbols");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        private set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Last name cannot be less than 3 symbols");
            }

            this.lastName = value;
        }
    }

    public int Age
    {
        get { return this.age; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or negative integer");
            }

            this.age = value;
        }
    }

    public double Salary
    {
        get { return this.salary; }
        set
        {
            if (value < 460)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva");
            }

            this.salary = value;
        }
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName} get {Salary:f2} leva";
    }

    public void IncreaseSalary(double bonus)
    {
        if (this.age > 30)
        {
            this.Salary += this.Salary * bonus / 100;
        }
        else
        {
            this.Salary += this.Salary * bonus / 200;
        }
    }
}