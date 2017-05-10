using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    public class Namespace: Identifier
    {
        public Namespace(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Namespace);
            return renamedItem;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                var usings = TreeHelper.GetDescendantNodes(root, "using_directive");
                foreach (var directive in usings)
                {
                    var namesaceOrType = directive.GetChild(1);
                    for (int i = 0; i < namesaceOrType.ChildCount; i++)
                    {
                        if (namesaceOrType.GetChild(i).ChildCount == 1)
                        {
                            if (namesaceOrType.GetChild(i).GetChild(0).GetText() == renamedItem.OriginalName)
                            {
                                var identifierNode = (CSParser.IdentifierContext)namesaceOrType.GetChild(i);
                                CSIdentifierHelper.ChangeName(identifierNode, renamedItem.GeneratedName);
                            }
                        }
                    }
                }
            }
        }
    }
}
