﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitExampleConsole
{
    public class Fruit: IWeightable
    {
        public string Name { get; private set; }

        public string Color { get; set; }

        public string Taste { get; set; }

        private int weight;

        public Fruit(string name)
        {
            Name = name;
        }

        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public void SetWeightInGrams(int weight)
        {
            this.weight = weight;
        }

        public int GetWeightInGrams()
        {
            return weight;
        }
    }
}
