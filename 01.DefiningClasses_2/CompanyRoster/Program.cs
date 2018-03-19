using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var employees = new Dictionary<string, Department>();

        var n = int.Parse(Console.ReadLine());
        GatherAllInput(employees, n);

        foreach (var department in employees.Values)
        {
            department.GetDepartmentAverageSalary();
        }

        var dept = employees.Values.OrderByDescending(d => d.AverageSalary).First();
        PrintResult(dept);
    }

    private static void PrintResult(Department dept)
    {
        Console.WriteLine($"Highest Average Salary: {dept.Name}");
        foreach (var employee in dept.Employees.OrderByDescending(e => e.Salary))
        {
            var email = employee.Email != default(string) ? employee.Email : "n/a";
            var age = employee.Age != default(int) ? employee.Age : -1;
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {email} {age}");
        }
    }

    private static void GatherAllInput(Dictionary<string, Department> employees, int n)
    {
        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var name = input[0];
            var salary = decimal.Parse(input[1]);
            var position = input[2];
            var department = input[3];
            var employee = new Employee(name, salary, position, department);

            if (input.Length == 5)
            {
                if (input[4].Contains("@"))
                {
                    employee.Email = input[4];
                }
                else
                {
                    employee.Age = int.Parse(input[4]);
                }
            }
            else if (input.Length == 6)
            {
                employee.Email = input[4];
                employee.Age = int.Parse(input[5]);
            }

            if (!employees.ContainsKey(department))
            {
                employees[department] = new Department(department);
            }

            employees[department].Employees.Add(employee);
        }
    }
}