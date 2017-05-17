using Antlr4.Runtime;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities.CSharpIdentifiers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class FunctionInterleavingManager
    {
        public static void TryToInterleaveFunctions(ParserRuleContext context, Root rootContext) { }
    }
}
