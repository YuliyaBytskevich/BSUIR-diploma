// файл IWeightable.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitExampleConsole
{
    public interface IWeightable
    {
        void SetWeightInGrams(int weight, int fault);
        
        int GetWeightInGrams();
    }
}
