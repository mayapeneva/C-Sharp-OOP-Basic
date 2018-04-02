namespace Google_Exercise
{
    public class Parent
    {
        private string parentName;
        public string parentBirthday;

        public Parent(string parentName, string parentBirthday)
        {
            this.parentName = parentName;
            this.parentBirthday = parentBirthday;
        }

        public string ParentName => this.parentName;
    }
}