using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Managers;

namespace Obfuscation.Core.CSharpAnalysis
{
    public class MethodInlineVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitMethod_invocation(CSParser.Method_invocationContext context)
        {
            MethodInlineManager.Inline(context, root);

            return VisitChildren(context);
        }
    }
}
