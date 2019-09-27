using System;
namespace NeedForSpeed
{
    public class Vehicle
    {

        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        protected double fuelConsumption = 1.25;
        public virtual double FuelConsumption 
        {
                 get {
                return fuelConsumption;
                    }
            }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public virtual void Drive (double kilometers)
        {

            this.Fuel -= kilometers*FuelConsumption;
        }
    }
}
