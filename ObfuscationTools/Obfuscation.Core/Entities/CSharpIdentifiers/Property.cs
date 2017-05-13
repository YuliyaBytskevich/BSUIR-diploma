using Obfuscation.Core.CSharpAnalysis;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Property : Identifier
    {
        public Property(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            if (context.GetChild(0).GetText() != "Type")
            {
                renamedItem = RenameIdentifier(context, RenameItemType.Property);
                return renamedItem;
            }
            return null;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                RenameInUsage(renamedItem.OriginalName, renamedItem.GeneratedName, renamedItem.Location);
            }
        }
    }
}
