namespace Google_Exercise
{
    public class Child
    {
        private string childName;
        public string childBirthday;

        public Child(string childName, string childBirthday)
        {
            this.childName = childName;
            this.childBirthday = childBirthday;
        }

        public string ChildName => this.childName;
    }
}
