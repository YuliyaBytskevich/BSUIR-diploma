using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Managers;
using Antlr4.Runtime.Misc;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class CodeRestructuringVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitString_literal([NotNull] CSParser.String_literalContext context)
        {
            //ConstantStringsManager.TryToHideConstantString(context, root);
            RedundantCodeManager.TryToAddRedundantCode(context, root);

            return VisitChildren(context);
        }

        public override Root VisitStatement([NotNull] CSParser.StatementContext context)
        {
            return base.VisitStatement(context);
        }
    }
}
