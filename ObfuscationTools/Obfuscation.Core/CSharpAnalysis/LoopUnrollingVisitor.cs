using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Managers;

namespace Obfuscation.Core.CSharpAnalysis
{
    class LoopUnrollingVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitForStatement(CSParser.ForStatementContext context)
        {
            LoopUnrollingManager.UnrollFor(context);

            return VisitChildren(context);
        }


    }
}
