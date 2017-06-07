using Antlr4.Runtime;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities.CSharpIdentifiers;
using Obfuscation.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class BogusClassesManager
    {
        public static Random random = new Random();

        public static void TryToAddBogusClass(ParserRuleContext context, string sourceDirectory, int numOfClasses)
        {
            var classes = RetrieveClassesCode(sourceDirectory, numOfClasses);
            var namespaces = TreeHelper.GetDescendantNodes(context, "namespace_body");
        }

        private static IEnumerable<string> RetrieveClassesCode(string sourceDirectory, int numOfClasses)
        {
            List<string> result = new List<string>();

            return result;
        }
    }
}
