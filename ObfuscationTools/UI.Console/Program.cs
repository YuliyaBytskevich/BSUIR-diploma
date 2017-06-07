using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Obfuscation.Core;

namespace UI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var obfuscator = new Obfuscator();
            //obfuscator.ObfuscateCSharpCode(@"C:\Users\julia\Desktop\BSUIR.Diploma\ObfuscationTools\CODE EXAMPLES\FruitExampleConsole\FruitExampleConsole.sln");
            //obfuscator.ObfuscateCSharpCode(@"D:\diploma\ObfuscationTools\CODE EXAMPLES\FruitExampleConsole\FruitExampleConsole.sln");

            obfuscator.ObfuscateCilCode(@"D:\diploma\ObfuscationTools\CODE EXAMPLES\FruitExampleConsole\FruitExampleConsole\bin\Debug\FruitExampleConsole.exe");

            System.Console.ReadKey();
        }
    }
}


