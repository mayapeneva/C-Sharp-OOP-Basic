using System;

namespace Mankind_EXER
{
    public class Worker : Human
    {
        private double weekSalary;
        private double workingHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, double workingHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkingHoursPerDay = workingHoursPerDay;
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            protected set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weekSalary = value;
            }
        }

        public double WorkingHoursPerDay
        {
            get { return this.workingHoursPerDay; }
            protected set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                this.workingHoursPerDay = value;
            }
        }

        public double CalculateSalaryPerHour()
        {
            return this.WeekSalary / (this.WorkingHoursPerDay * 5);
        }
    }
}