using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Diagnostics;

namespace Antlr_Test_1
{
    class Program
    {
        static CSharpParser.Compilation_unitContext tree = null;
        static CSharpParser parser = null;
        
        static void Main(string[] args)
        {
            var sampleCode = File.ReadAllText(Path.GetFullPath(@"..\..\") + "Hello.cs");
            
            var lexer = new CSharpLexer(new AntlrInputStream(sampleCode));
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            //tokenStream.Fill();
            //var tokens = tokenStream.GetTokens();
            //foreach (var t in tokens)
            //{
            //    Console.WriteLine(t.ToString());
            //}

            parser = new CSharpParser(tokenStream);
            tree = parser.compilation_unit();
            PrintPretty(tree, "", true);

            Console.ReadLine();
        }


        static void PrintPretty(IParseTree node, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }

            var text = node.ToString();

            if (text.Contains("["))
            {
                text = text.Replace("[", "");
                text = text.Replace("]", "");
                if (text != string.Empty)
                {
                    var stateCode = int.Parse(text.Split(' ').First());
                    var stateName = parser.GetStateName(stateCode);
                    if (stateName != null)
                    {
                        text = "[" + stateName + "]";
                    }
                    else
                    {
                        Debug.WriteLine(">>> STATE NAME IS MISSING. CODE: " + stateCode);
                    }
                }
                else
                {
                    text = "";
                }
            }
            else
            {
                text = "\"" + text + "\"";
            }

            Console.WriteLine(text);
            for (int i = 0; i < node.ChildCount; i++)
            {
                PrintPretty(node.GetChild(i), indent, i == node.ChildCount - 1);
            }
        }

    }
}
