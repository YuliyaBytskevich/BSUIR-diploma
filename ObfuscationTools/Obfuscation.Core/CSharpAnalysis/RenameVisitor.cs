using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Obfuscation.Core.Entities;
using Obfuscation.Core.Managers;

namespace Obfuscation.Core.CSharpAnalysis
{
    internal class RenameVisitor : CSParserBaseVisitor<Root>
    {
        protected override Root DefaultResult { get { return root; } }
        private Root root = null;
        private string newIdentifierBase;

        public RenameVisitor(string newIdentifierBase)
        {
            if (!string.IsNullOrEmpty(newIdentifierBase))
            {
                this.newIdentifierBase = newIdentifierBase;
            }
            else
            {
                this.newIdentifierBase = DefaultValues.IdentifiersBaseString;
            }
        }

        public override Root VisitCompilation_unit(Root context)
        {
            IdentifiersGenerator.SetGenerator(newIdentifierBase, 0);
            this.root = context;
            return VisitChildren(root);
        }

        public override Root VisitIdentifier(CSParser.IdentifierContext context)
        {
            RenameManager.TryToRenameIdentifier(context, root);

            return VisitChildren(context);
        }
    }
}
