﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    class Cargo
    {
        public string Type { get; set; }
        public int Weight { get; set; }


        public Cargo(int weight, string type)
        {
            Weight = weight;
            Type = type;
        }
    }
}