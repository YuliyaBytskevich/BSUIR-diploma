using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Managers;
using Obfuscation.Core.Entities;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class LoopUnrollingVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;
        private int unrollingCount = 0;

        public LoopUnrollingVisitor(int unrollingCount = 0)
        {
            if (unrollingCount > 0)
            {
                this.unrollingCount = unrollingCount;
            }
            else
            {
                this.unrollingCount = DefaultValues.UnrollingCount;
            }
        }

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitForStatement(CSParser.ForStatementContext context)
        {
            LoopUnrollingManager.UnrollFor(context, unrollingCount);

            return VisitChildren(context);
        }


    }
}
