using System.Collections.Generic;
using System.Linq;

public class Department
{
    public Department(string name)
    {
        this.Name = name;
        this.Employees = new List<Employee>();
    }

    public string Name { get; }
    public List<Employee> Employees { get; }

    public decimal AverageSalary { get; private set; }

    public void GetDepartmentAverageSalary()
    {
        this.AverageSalary = this.Employees.Select(e => e.Salary).Average();
    }
}