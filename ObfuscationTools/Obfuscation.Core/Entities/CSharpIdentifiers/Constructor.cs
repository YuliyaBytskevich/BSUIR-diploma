using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Constructor : Identifier
    {
        public Constructor(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            return RenameIdentifier(context, RenameItemType.Constructor);
        }

        public override void RenameInUsage()
        {
            // do nothing (method is here for polymorphism support)
        }

        protected override RenameItem RenameIdentifier(CSParser.IdentifierContext context, RenameItemType type)
        {
            string original = context.GetChild(0).GetText();
            CSIdentifierHelper.ChangeName(context, RenameTable.GetGenerated(original, RenameItemType.Class));

            return RenameTable.GetItem(original, RenameItemType.Class);
        }
    }
}
