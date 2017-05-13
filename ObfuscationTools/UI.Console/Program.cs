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
            //Obfuscator.ObfuscateCSharpCode(@"C:\Users\julia\Desktop\BSUIR.Diploma\ObfuscationTools\CODE EXAMPLES\Hello.cs");
            Obfuscator.ObfuscateCSharpCode(@"C: \Users\julia\Desktop\BSUIR.Diploma\ObfuscationTools\CODE EXAMPLES\FruitExampleConsole\FruitExampleConsole.sln");

            
            System.Console.ReadKey();
        }
    }
}
