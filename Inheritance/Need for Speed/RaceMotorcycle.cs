using System;
namespace NeedForSpeed
{
    public class RaceMotorcycle:Motorcycle
    {
        public override double FuelConsumption => 8;

        public RaceMotorcycle(int horse, double fuel)
            : base (horse,fuel)
        {
        }
    }
}
