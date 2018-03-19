namespace CatLady
{
    public class Cymric : Cat
    {
        public Cymric(string name, double furLength)
            : base(name)
        {
            this.FurLength = furLength;
        }

        public double FurLength { get; }

        public override string ToString()
        {
            return $"{this.GetType().Name} {this.Name} {this.FurLength:f2}";
        }
    }
}