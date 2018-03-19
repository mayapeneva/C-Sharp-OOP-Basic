public class Company
{
    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    public string Name { get; }
    public string Department { get; }
    public decimal Salary { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:f2}";
    }
}