using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {

        private string name;
        private List<string> items;

        public Planet(string name)
        {
            Name = name;
            items = new List<string>();
        }

        public ICollection<string> 
        Items => this.items;
        //public ICollection<string> Items { get; set; }
        public string Name { get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                name = value;
            }
        }
    }
}

