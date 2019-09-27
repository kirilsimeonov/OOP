using System;
namespace Restaurant
{
    public class Cake:Dessert
    {
        private const double CakeGrams = 250;
        private const double CakeCalories = 1000;
        private const decimal CakePrice = 5m;

        //public Dessert(string name, decimal price, double grams,double calories)

        public Cake(string name)
            :base(name,CakePrice,CakeGrams,CakeCalories)
        {
        }
    }
}
