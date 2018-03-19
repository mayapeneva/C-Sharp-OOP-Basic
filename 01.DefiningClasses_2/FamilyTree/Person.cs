using System;
using System.Collections.Generic;

public class Person
{
    public Person()
    {
        this.Name = default(string);
        this.BirthDay = default(DateTime);
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public Person(string name) : this()
    {
        this.Name = name;
    }

    public Person(DateTime birthDay) : this()
    {
        this.BirthDay = birthDay;
    }

    public Person(string name, DateTime birthDay) : this()
    {
        this.Name = name;
        this.BirthDay = birthDay;
    }

    public string Name { get; set; }
    public DateTime BirthDay { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthDay}";
    }
}