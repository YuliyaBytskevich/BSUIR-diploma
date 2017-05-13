using Antlr4.Runtime.Tree;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class PrintVisitor : CSParserBaseVisitor<string>
    {
        private string result = "";
        protected override string DefaultResult { get { return result; } }


        public override string VisitCompilation_unit(Root context)
        {
            return VisitChildren(context);
        }

        public override string VisitTerminal(ITerminalNode node)
        {
            result += node.GetText() + " ";
            return DefaultResult;
        }
    }
}
