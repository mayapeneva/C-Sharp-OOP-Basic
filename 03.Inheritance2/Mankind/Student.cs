using System;
using System.Linq;
using System.Text;

public class Student : Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => this.facultyNumber;
        private set
        {
            if (!value.All(char.IsLetterOrDigit) || value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.Append(base.ToString());
        result.AppendLine($"Faculty number: {this.FacultyNumber}");

        return result.ToString();
    }
}