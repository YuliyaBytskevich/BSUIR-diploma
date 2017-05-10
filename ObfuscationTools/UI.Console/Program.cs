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
            // ObfuscationTools.Obfuscator.ObfuscateCSharpCode(@"D:\VS Projects\Antlr_Test_1\CODE EXAMPLES\Hello.cs");
            Obfuscator.ObfuscateCSharpCode(@"D:\VS Projects\FruitExampleConsole\FruitExampleConsole.sln");

            System.Console.ReadKey();
        }
    }
}
