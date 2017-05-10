using Obfuscation.Core.CSharpAnalysis;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    public class Indexer : Identifier
    {
        public Indexer(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Indexer);
            return renamedItem;
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
