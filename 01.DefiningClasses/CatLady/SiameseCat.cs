namespace CatLady
{
    public class Siamese : Cat
    {
        public Siamese(string name, double earSize)
            : base(name)
        {
            this.EarSize = earSize;
        }

        public double EarSize { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.EarSize:f0}";
        }
    }
}