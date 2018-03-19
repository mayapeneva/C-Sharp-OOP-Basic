using System;
using System.Text;

public class Worker : Human
{
    private decimal salary;
    private decimal workingHours;

    public Worker(string firstName, string lastName, decimal salary, decimal workingHours)
        : base(firstName, lastName)
    {
        this.Salary = salary;
        this.WorkingHours = workingHours;
    }

    public decimal Salary
    {
        get => this.salary;
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.salary = value;
        }
    }

    public decimal WorkingHours
    {
        get => this.workingHours;
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workingHours = value;
        }
    }

    private decimal CalculateSalaryPerHour()
    {
        return this.salary / (this.workingHours * 5);
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append(base.ToString());
        result.AppendLine($"Week Salary: {this.Salary:f2}");
        result.AppendLine($"Hours per day: {this.WorkingHours:f2}");
        result.AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");

        return result.ToString();
    }
}