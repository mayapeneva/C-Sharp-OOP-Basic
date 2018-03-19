namespace CatLady
{
    public class StreetExtraordinaire : Cat
    {
        public StreetExtraordinaire(string name, double decibelsOfMeows)
            : base(name)
        {
            this.DecibelsOfMeows = decibelsOfMeows;
        }

        public double DecibelsOfMeows { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.DecibelsOfMeows:f0}";
        }
    }
}