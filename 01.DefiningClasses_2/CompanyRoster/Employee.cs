public class Employee
{
    public Employee(string name, decimal salary, string position, string department)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
    }

    public string Name { get; }
    public decimal Salary { get; }
    public string Position { get; }
    public string Department { get; }
    public string Email { get; set; }
    public int Age { get; set; }
}