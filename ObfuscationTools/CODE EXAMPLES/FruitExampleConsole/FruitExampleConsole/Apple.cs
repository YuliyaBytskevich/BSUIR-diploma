using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitExampleConsole
{
    public class Apple: Fruit
    {
        public string description;

        public Apple(string name) : base(name) { }

        public Apple(string name, string color) : base(name, color) { }

        public override string ToString()
        {
            description = "Apple: " + Name + "(" + Color + ", " + Taste + ")";

            return description;
        }
    }
}
