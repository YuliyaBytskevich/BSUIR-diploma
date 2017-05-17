using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Managers;
using Antlr4.Runtime.Misc;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class VariablesAssociationVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitVariable_declarator([NotNull] CSParser.Variable_declaratorContext context)
        {
            return base.VisitVariable_declarator(context);
        }
    }
}
