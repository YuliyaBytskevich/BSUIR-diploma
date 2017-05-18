// файл Fruit.cs
using System;
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

        public int weight;

        public Fruit(string name)
        {
            Name = name;
        }

        public Fruit(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public void SetWeightInGrams(int weight, int fault)
        {
            Console.WriteLine("Here is useless code inside method SetWeightInGrams");
            Console.WriteLine("Here is one more peace of useless code");
            Console.WriteLine("Hello :)");
            this.weight = weight + fault;
        }

        public int GetWeightInGrams()
        {
            return weight;
        }
    }
}
