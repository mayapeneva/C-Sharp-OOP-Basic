namespace CompanyRoster_Exercise
{
    public class Employee
    {
        private string name;
        private double salary;
        private string position;
        private string department;

        public Employee(string name, double salary, string position, string department)
        {
            this.name = name;
            this.salary = salary;
            this.position = position;
            this.department = department;
        }

        public string Name => this.name;

        public double Salary => this.salary;

        public string Position => this.position;

        public string Department => this.department;

        public string Email { get; set; }

        public int Age { get; set; }
    }
}
