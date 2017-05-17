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
using System.Collections.Generic;
using Obfuscation.Core.CilAnalysis;

namespace Obfuscation.Core
{
    public class Obfuscator: ICSharpObfuscator, ICilObfuscator
    {
        private static ConfigurationManager config = null;
        private static string code = null;
        private static CSParser parser = null;

        #region ICSharpObfuscator members
        public void ObfuscateCSharpCode(string cSharpFilePath)
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
                    var param = config.Renaming.Params != null ? config.Renaming.Params[0] : null;
                    var renameVisitor = new RenameVisitor(param);
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

        public string RenameIdentifiers(string cSharpCode, string identifierBase = null)
        {
            throw new NotImplementedException();
        }

        public string InlineMethods(string cSharpCode, double inliningCoefficient = 1)
        {
            throw new NotImplementedException();
        }

        public string UnrollLoops(string cSharpCode, double unrollingCoefficient = 1)
        {
            throw new NotImplementedException();
        }

        public string InterleaveFuctions(string cSharpCode, int interleavesCount = 1)
        {
            throw new NotImplementedException();
        }

        public string AddRedundantCode(string cSharpCode, int redundantCodePercent = 10)
        {
            throw new NotImplementedException();
        }

        public string EncryptConstantStrings(string cSharpCode, string key = null)
        {
            throw new NotImplementedException();
        }

        public string AssociateVariables(string cSharpCode, IEnumerable<string> types = null)
        {
            throw new NotImplementedException();
        }

        public string AddBogusClasses(string cSharpCode, int bogusClassesCount = 1)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ICilObfuscator members
        public void ObfuscateCilCode(string exeFilePath)
        {
            var controlFlowManager = new CodeRestructurer();
            var codeManager = new CodeRestructurer();
        }

        public string RestructControlFlow(string cilCode)
        {
            throw new NotImplementedException();
        }

        public string AddRedundantCode(string cilCode)
        {
            throw new NotImplementedException();
        }

        public string AddUnreachableCode(string cilCode)
        {
            throw new NotImplementedException();
        }

        public string AddUnconditionalTransition(string cilCode)
        {
            throw new NotImplementedException();
        }
        #endregion

        private Root ParseCode(string code)
        {
            var lexer = new CSLexer(new AntlrInputStream(code));
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            parser = new CSParser(tokenStream);
            return parser.compilation_unit();
        }

        private string ReadSources(string path)
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

        private void PrintPretty(IParseTree node, string indent, bool last)
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
