using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var departments = new Dictionary<string, Department>();
            OrderEmployeesByDepartment(n, departments);

            foreach (var dep in departments)
            {
                dep.Value.GetAverageSalary();
            }

            PrintResult(departments.Values.OrderByDescending(d => d.AverageSalary).FirstOrDefault());
        }

        private static void OrderEmployeesByDepartment(int n, Dictionary<string, Department> departments)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var name = input[0];
                var salary = double.Parse(input[1]);
                var position = input[2];
                var department = input[3];
                var email = "n/a";
                var age = -1;
                if (input.Length > 4)
                {
                    if (input[4].Contains('@'))
                    {
                        email = input[4];
                        if (input.Length == 6)
                        {
                            age = int.Parse(input[5]);
                        }
                    }
                    else
                    {
                        age = int.Parse(input[4]);
                    }
                }

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new Department();
                    departments[department].deptName = department;
                }

                departments[department].Employees.Add(new Employee(name, salary, position, department) { Email = email, Age = age });
            }
        }

        private static void PrintResult(Department department)
        {
            Console.WriteLine($"Highest Average Salary: {department.deptName}");
            foreach (var employee in department.Employees.OrderByDescending(e => e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}