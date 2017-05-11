using System;
using System.Linq;
using Obfuscation.Core.CSharpAnalysis;
using Antlr4.Runtime;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using System.Diagnostics;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.Helpers;
using Obfuscation.Core.Entities;
using System.IO;
using Obfuscation.Core.Managers;

namespace Obfuscation.Core
{
    public static class Obfuscator
    {
        private static ConfigurationManager config = null;
        private static string code = null;
        private static CSParser parser = null;

        public static void ObfuscateCSharpCode(string cSharpFilePath)
        {
            config = new ConfigurationManager();
            if (config != null)
            {
                code = ReadSources(cSharpFilePath);
                Console.WriteLine(code);

                var tree = ParseCode(code);
                Console.WriteLine("BEFORE: ");
                PrintPretty(tree, "", true);


                if (config.LoopUnrolling.IsEnabled)
                {
                    var loopUnrollingVisitor = new LoopUnrollingVisitor();
                    tree = loopUnrollingVisitor.Visit(tree);
                }

                if (config.FunctionInlining.IsEnabled)
                {
                    var methodInlineVisitor = new MethodInlineVisitor();
                    tree = methodInlineVisitor.Visit(tree);
                }

                if (config.Renaming.IsEnabled)
                {
                    var renameVisitor = new RenameVisitor();
                    tree = renameVisitor.Visit(tree);
                }

                // tree -> text 
                var printVisitor = new PrintVisitor();
                //var obfuscated = printVisitor.Visit(renamedTree);
                var obfuscated = printVisitor.Visit(tree);

                Console.WriteLine("-------------------------------------------------------\n\nAFTER:\n");
                Console.WriteLine(CodeFormattingHelper.CorrectCSFormatting(obfuscated));
                FilesHelper.WriteToFile(CodeFormattingHelper.CorrectCSFormatting(obfuscated), cSharpFilePath + "_obf.cs");

                //PrintPretty(treeVithInlinedMethods, "", true);

                Console.WriteLine(RenameTable.ToString());
            }
        }

        private static Root ParseCode(string code)
        {
            var lexer = new CSLexer(new AntlrInputStream(code));
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            parser = new CSParser(tokenStream);
            return parser.compilation_unit();
        }

        private static string ReadSources(string path)
        {
            var extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".cs":
                    return FilesHelper.ReadFile(path);
                case ".sln":
                    return FilesHelper.ReadSlnFile(path);
                case ".csproj":
                    return FilesHelper.ReadCsprojFile(path);
                default:
                    throw new ArgumentException("File extension must be one of the following: .cs/.sln/.csproj.");
            }
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

            if (!string.IsNullOrEmpty(text) && text.Contains("["))
            {
                text = text.Replace("[", "");
                text = text.Replace("]", "");
                if (text != string.Empty)
                {
                    try
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
                    catch
                    {
                        Debug.WriteLine(">>> ERROR OCCURED IN TEXT: " + text);
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
