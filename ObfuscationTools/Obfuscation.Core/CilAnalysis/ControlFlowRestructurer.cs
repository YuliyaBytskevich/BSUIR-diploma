using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Ast;
using System.IO;

namespace Obfuscation.Core.CilAnalysis
{
    internal class ControlFlowRestructurer
    {
        public string RestructureControlFlow(Mono.Cecil.AssemblyDefinition assemblyDefinition, AstBuilder tree) 
        {
            foreach (var typeInAssembly in assemblyDefinition.MainModule.Types)
            {
                if (typeInAssembly.IsPublic)
                {
                    
                    
                    foreach (var method in typeInAssembly.Methods)
                    {
                        if (method.IsPublic && !method.IsGetter && !method.IsSetter && !method.IsConstructor)
                        {
                            tree.AddMethod(method);

                            StringWriter output = new StringWriter();
                            tree.GenerateCode(new PlainTextOutput(output));
                            string result = output.ToString();
                            output.Dispose();

                            return result;
                        }
                    }
                }
            }

            return null;
        }

        public string AddUnconditionalTransitions() { return null; }
    }
}
