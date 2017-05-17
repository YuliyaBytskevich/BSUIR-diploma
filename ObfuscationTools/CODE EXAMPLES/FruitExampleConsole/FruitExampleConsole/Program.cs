using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitExampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var first = new Apple("Golden", "yellow");
            //first.Taste = "sweet";

            var second = new Apple("Granny Smith");
            //second.Color = "green";
            //second.Taste = "sweet/sour";
            var smth = 210;
            second.SetWeightInGrams(666, smth);
            var x = second.GetWeightInGrams();

            //IWeightable third = new Apple("Red prince");
        }
    }
}
