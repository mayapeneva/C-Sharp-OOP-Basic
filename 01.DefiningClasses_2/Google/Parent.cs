public class Parent
{
    public Parent(string name, string birthDay)
    {
        this.Name = name;
        this.BirthDay = birthDay;
    }

    public string Name { get; }
    public string BirthDay { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.BirthDay}";
    }
}