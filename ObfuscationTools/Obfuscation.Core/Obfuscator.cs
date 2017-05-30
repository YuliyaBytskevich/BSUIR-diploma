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
using Obfuscation.Core.Exceptions;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using ICSharpCode.Decompiler.ILAst;

namespace Obfuscation.Core
{
    public class Obfuscator : ICSharpObfuscator, ICilObfuscator
    {
        private static ConfigurationManager config;
        private static string code;
        private static CSParser parser;

        public Obfuscator()
        {
            config = new ConfigurationManager();
        }

        #region ICSharpObfuscator members
        public void ObfuscateCSharpCode(string cSharpFilePath)
        {
            if (config == null)
            {
                throw new MissingConfigurationException();
            }

            if (!config.CSharpConfigExists())
            {
                throw new MissingConfigurationException(DefaultValues.CSharpConfigSectionName);
            }

            code = ReadSources(cSharpFilePath);
            var tree = ParseCode(code);
            PrintPretty(tree, "", true);

            if (config.ConstantStringsEncryption.IsEnabled)
            {
                code += ConstantStringsManager.GetDecodingMethodDeclaration();
            }

            if (config.AddingRedundantCodeCS.IsEnabled)
            {
                var codeRestructurngVisitor = new CodeRestructuringVisitor();
                tree = codeRestructurngVisitor.Visit(tree);
            }

            if (config.ConstantStringsEncryption.IsEnabled)
            {
                var constantStringsVisitor = new ConstantStringsVisitor();
                tree = constantStringsVisitor.Visit(tree);
            }

            if (config.LoopUnrolling.IsEnabled)
            {
                var stringParam = config.LoopUnrolling.Params != null ? config.LoopUnrolling.Params[0] : null;
                var intParam = 0;
                int.TryParse(stringParam, out intParam);

                var loopUnrollingVisitor = new LoopUnrollingVisitor(intParam);
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
            var obfuscated = printVisitor.Visit(tree);

            Console.WriteLine("-------------------------------------------------------\n\nAFTER:\n");

            //PrintPretty(tree, "", true);
            Console.WriteLine(CodeFormattingHelper.CorrectCSFormatting(obfuscated));
            FilesHelper.WriteToFile(CodeFormattingHelper.CorrectCSFormatting(obfuscated), cSharpFilePath + "_obf.cs");

            //Console.WriteLine(RenameTable.ToString());
        }

        public string RenameIdentifiers(string cSharpCode, string identifierBase = null)
        {
            var tree = ParseCode(cSharpCode);
            var renameVisitor = new RenameVisitor(identifierBase);
            tree = renameVisitor.Visit(tree);
            var printVisitor = new PrintVisitor();

            return printVisitor.Visit(tree);
        }

        public string InlineMethods(string cSharpCode, double inliningCoefficient = 1)
        {
            var tree = ParseCode(cSharpCode);
            var methodInlineVisitor = new MethodInlineVisitor();
            tree = methodInlineVisitor.Visit(tree);
            var printVisitor = new PrintVisitor();

            return printVisitor.Visit(tree);
        }

        public string UnrollLoops(string cSharpCode, int unrollingCoefficient = 1)
        {
            var tree = ParseCode(cSharpCode);
            var loopUnrollingVisitor = new LoopUnrollingVisitor(unrollingCoefficient);
            tree = loopUnrollingVisitor.Visit(tree);
            var printVisitor = new PrintVisitor();

            return printVisitor.Visit(tree);
        }

        public string InterleaveFuctions(string cSharpCode, int interleavesCount = 1)
        {
            throw new NotImplementedException();
        }

        public string AddRedundantCode(string cSharpCode, int redundantCodePercent = 10)
        {
            var tree = ParseCode(cSharpCode);
            var codeRestructurngVisitor = new CodeRestructuringVisitor();
            tree = codeRestructurngVisitor.Visit(tree);
            var printVisitor = new PrintVisitor();

            return printVisitor.Visit(tree);
        }

        public string EncryptConstantStrings(string cSharpCode, string key = null)
        {
            var tree = ParseCode(cSharpCode);
            var constantStringsVisitor = new ConstantStringsVisitor();
            tree = constantStringsVisitor.Visit(tree);
            var printVisitor = new PrintVisitor();

            return printVisitor.Visit(tree);
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
            if (config == null)
            {
                throw new MissingConfigurationException();
            }

            if (!config.CilConfigExists())
            {
                throw new MissingConfigurationException(DefaultValues.CilConfigSectionName);
            }

            ControlFlowRestructurer controlManager = new ControlFlowRestructurer();
            CodeRestructurer codeManager = new CodeRestructurer();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.ReflectionOnlyLoadFrom(exeFilePath);
            Mono.Cecil.AssemblyDefinition assemblyDefinition = Mono.Cecil.AssemblyDefinition.ReadAssembly(exeFilePath);
            AstBuilder tree = new AstBuilder(new ICSharpCode.Decompiler.DecompilerContext(assemblyDefinition.MainModule));
            ILAstBuilder ilTree = new ILAstBuilder();
            List<List<ILNode>> ilMethods = new List<List<ILNode>>();

            foreach (var typeInAssembly in assemblyDefinition.MainModule.Types)
            {
                tree.AddType(typeInAssembly);

                foreach (var method in typeInAssembly.Methods)
                {
                    if (method.Body != null)
                    {
                        var newMethod = ilTree.Build(method, false, new ICSharpCode.Decompiler.DecompilerContext(assemblyDefinition.MainModule));
                        if (newMethod != null)
                        {
                            ilMethods.Add(newMethod);
                        }
                    }
                }
            }

            Console.WriteLine(tree.SyntaxTree.ToString());
            
            



            //if (config.ControlFlowRestructuring.IsEnabled)
            //{
            //    controlManager.RestructureControlFlow();
            //}

            //if (config.UsingUnconditionalTransition.IsEnabled)
            //{
            //    controlManager.AddUnconditionalTransitions();
            //}

            //if (config.AddingUnreachableCode.IsEnabled)
            //{
            //    codeManager.AddUnreachableCode();
            //}

            //if (config.AddingRedundantCodeCIL.IsEnabled)
            //{
            //    codeManager.AddRedundantCode();
            //}
            // Code to generate code for all the types inside an assembly:

            //foreach (var typeInAssembly in assemblyDefinition.MainModule.Types)
            //{
            //    if (typeInAssembly.IsPublic)
            //    {
            //        Console.WriteLine("T:{0}", typeInAssembly.Name);
            //        //just reset the builder to include only code for a single type
            //        tree = new AstBuilder(new ICSharpCode.Decompiler.DecompilerContext(assemblyDefinition.MainModule) { CurrentType = typeInAssembly });
            //        tree.AddType(typeInAssembly);
            //        StringWriter output = new StringWriter();
            //        tree.GenerateCode(new PlainTextOutput(output));
            //        string result = output.ToString();
            //        output.Dispose();
            //    }
            //}

            //Console.WriteLine("-----------------------------------------------------");

            ////Code to generate code for all the public methods inside an assembly:
            //foreach (var typeInAssembly in assemblyDefinition.MainModule.Types)
            //{
            //    if (typeInAssembly.IsPublic)
            //    {
            //        Console.WriteLine("T:{0}", typeInAssembly.Name);
            //        foreach (var method in typeInAssembly.Methods)
            //        {
            //            //just reset the builder to include only code for a single method
            //            tree = new AstBuilder(new ICSharpCode.Decompiler.DecompilerContext(assemblyDefinition.MainModule) { CurrentType = typeInAssembly });
            //            tree.AddMethod(method);
            //            if (method.IsPublic && !method.IsGetter && !method.IsSetter && !method.IsConstructor)
            //            {
            //                Console.WriteLine("M:{0}", method.Name);
            //                StringWriter output = new StringWriter();
            //                tree.GenerateCode(new PlainTextOutput(output));
            //                string result = output.ToString();
            //                output.Dispose();
            //            }
            //        }
            //    }
            //}

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
