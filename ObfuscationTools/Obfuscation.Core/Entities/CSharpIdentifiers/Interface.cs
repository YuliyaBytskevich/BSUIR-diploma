using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using System.Linq;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Interface: Identifier
    {
         public Interface(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Interface);
            return renamedItem;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                var inheritanceNodes = TreeHelper.GetDescendantNodes(root, "interface_base").Concat(TreeHelper.GetDescendantNodes(root, "class_base"));
                foreach (var node in inheritanceNodes)
                {
                    var identifiers = TreeHelper.GetDescendantNodes(node, "identifier");
                    if (identifiers != null && identifiers.Count() == 1 && renamedItem.OriginalName == identifiers.First().GetChild(0).GetText())
                    {
                        CSIdentifierHelper.ChangeName(identifiers.First(), renamedItem.GeneratedName);
                    }
                }

                var typeNodes = TreeHelper.GetDescendantNodes(root, "type");
                foreach (var usage in typeNodes)
                {
                    var identifierNodes = TreeHelper.GetDescendantNodes(usage, "identifier");
                    if (identifierNodes != null && identifierNodes.Count() > 0)
                    {
                        var identifierNode = (CSParser.IdentifierContext)identifierNodes.First();
                        if (identifierNode.GetChild(0).GetText() == renamedItem.OriginalName)
                        {
                            CSIdentifierHelper.ChangeName(identifierNode, renamedItem.GeneratedName);
                        }
                    }
                }
            }
        }
    }
}
