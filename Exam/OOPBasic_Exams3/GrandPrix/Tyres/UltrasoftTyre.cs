using System;

public class UltrasoftTyre : Tyre
{
    private const string UltrasoftName = "Ultrasoft";

    public UltrasoftTyre(double hardness, double grip)
        : base(UltrasoftName, hardness)
    {
        this.Grip = grip;
    }

    public double Grip { get; }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }

            base.Degradation = value;
        }
    }

    public override void CompleteLap()
    {
        base.CompleteLap();
        this.Degradation -= this.Grip;
    }
}