using System.Collections.Generic;
using System.Linq;

public class Family
{
    public Family()
    {
        this.People = new List<Person>();
    }

    public List<Person> People { get; }

    public void AddMemeber(Person member)
    {
        this.People.Add(member);
    }

    public Person GetOldestMember()
    {
        var maxAge = this.People.Max(p => p.Age);
        return this.People.First(p => p.Age.Equals(maxAge));
    }
}