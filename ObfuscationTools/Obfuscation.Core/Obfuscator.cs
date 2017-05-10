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

namespace Obfuscation.Core
{
    public static class Obfuscator
    {
        private static string code = null;
        private static CSParser parser = null;

        public static void ObfuscateCSharpCode(string cSharpFilePath)
        {
            // file -> code text
            var extension = Path.GetExtension(cSharpFilePath);
            switch (extension)
            {
                case ".cs":
                    code = FilesHelper.ReadFile(cSharpFilePath);
                    break;
                case ".sln":
                    code = FilesHelper.ReadSlnFile(cSharpFilePath);
                    break;
                case ".csproj":
                    code = FilesHelper.ReadCsprojFile(cSharpFilePath);
                    break;
                default:
                    throw new ArgumentException("File extension must be one of the following: .cs/.sln/.csproj.");
            }

            Console.WriteLine(code);

            // text -> tree
            var tree = ParseCode(code);

            Console.WriteLine("BEFORE: ");
            PrintPretty(tree, "", true);



            // rename identifiers
            //var renameVisitor = new RenameVisitor();
            //var renamedTree = renameVisitor.Visit(tree);

            var methodInlineVisitor = new MethodInlineVisitor();
            var treeVithInlinedMethods = methodInlineVisitor.Visit(tree);

            // tree -> text 
            var printVisitor = new PrintVisitor();
            //var obfuscated = printVisitor.Visit(renamedTree);
            var obfuscated = printVisitor.Visit(treeVithInlinedMethods);

            Console.WriteLine("-------------------------------------------------------\n\nAFTER:\n");
            Console.WriteLine(CodeFormattingHelper.CorrectCSFormatting(obfuscated));
            FilesHelper.WriteToFile(CodeFormattingHelper.CorrectCSFormatting(obfuscated), cSharpFilePath + "_obf.cs");

            //PrintPretty(treeVithInlinedMethods, "", true);

            Console.WriteLine(RenameTable.ToString());
        }

        private static Root ParseCode(string code)
        {
            var lexer = new CSLexer(new AntlrInputStream(code));
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            parser = new CSParser(tokenStream);
            return parser.compilation_unit();
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
