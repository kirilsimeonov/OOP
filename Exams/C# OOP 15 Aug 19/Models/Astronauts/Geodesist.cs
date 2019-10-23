using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    class Geodesist : Astronaut
    {
        private const double initialOxygen = 50;

        public Geodesist(string name)
            : base(name, initialOxygen)
        {
        }

       

    }
}
