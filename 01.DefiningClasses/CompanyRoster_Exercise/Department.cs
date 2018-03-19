using System.Collections.Generic;
using System.Linq;

namespace CompanyRoster_Exercise
{
    public class Department
    {
        private List<Employee> employees;
        private double averageSalary;

        public Department()
        {
            this.employees = new List<Employee>();
        }

        public string deptName { get; set; }

        public List<Employee> Employees => this.employees;

        public double AverageSalary => this.averageSalary;

        public void GetAverageSalary()
        {
            this.averageSalary = Employees.Select(e => e.Salary).Average();
        }
    }
}
