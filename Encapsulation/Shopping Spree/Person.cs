using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {

        private string name;
        private decimal money;
        private List<Product> products;


        public string Name { 
        get => this.name;
           private set 
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            } 
            }
        public decimal Money
        {
            get => this.money;
           private set 
           {
                if (value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }

        }
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products.AsReadOnly();
            }
        }

        public void Buy (Product product)
        {
            if (product.Cost<=Money)
            {
                Money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

    }
}   
