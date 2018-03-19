using System;

public class UltrasoftTyre : Tyre
{
    private const string NameConst = "Ultrasoft";

    private double grip;

    public UltrasoftTyre(double hardness, double grip)
        : base(NameConst, hardness)
    {
        this.grip = grip;
    }

    public override double Degradation
    {
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException();
            }
        }
    }

    public override void Degradate()
    {
        base.Degradation -= this.Hardness + this.grip;
    }
}