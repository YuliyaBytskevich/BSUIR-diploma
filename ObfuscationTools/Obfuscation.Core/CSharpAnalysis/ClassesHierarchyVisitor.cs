using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Entities;
using Obfuscation.Core.Managers;
using Antlr4.Runtime.Misc;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class ClassesHierarchyVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;

        public override Root VisitCompilation_unit(Root context)
        {
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitClass_definition([NotNull] CSParser.Class_definitionContext context)
        {
            return base.VisitClass_definition(context);
        }
    }
}
