﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    class Biologist : Astronaut
    {
        private const double initialOxygen = 70;

        public Biologist(string name)
            : base(name, initialOxygen)
        {
        }

        public override void Breath()
        {
            if(Oxygen - 5 < 0)
            {
                Oxygen = 0;
            }
            else
            {
                Oxygen -= 5;
            }
        }

    }
}
