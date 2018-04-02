using System;
using System.Text.RegularExpressions;

namespace Mankind_EXER
{
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
            get { return this.facultyNumber; }
            protected set
            {
                var regex = new Regex(@"^([0-9a-zA-Z]{5,10})$");
                var match = regex.Match(value);
                if (!match.Success)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }
    }
}