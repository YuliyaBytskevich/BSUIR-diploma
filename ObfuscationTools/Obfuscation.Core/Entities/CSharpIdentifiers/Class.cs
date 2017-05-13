using System.Linq;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Class : Identifier
    {
        public Class(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Class);
            return renamedItem;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                var instanceCreations = TreeHelper.GetDescendantNodes(root, "object_creation_expression");
                foreach (var creation in instanceCreations)
                {
                    var classIdentifiers = TreeHelper.GetDescendantNodes(creation.parent, "identifier");
                    if (classIdentifiers.Count() == 1)
                    {
                        var identifierNode = (CSParser.IdentifierContext)classIdentifiers.First();
                        if (identifierNode.GetChild(0).GetText() == renamedItem.OriginalName)
                        {
                            CSIdentifierHelper.ChangeName(identifierNode, renamedItem.GeneratedName);
                        }
                    }
                }

                var methodInvocations = TreeHelper.GetDescendantNodes(root, "method_invocation");
                foreach (var invocation in methodInvocations)
                {
                    var firstIdentifier = (CSParser.IdentifierContext)TreeHelper.GetDescendantNodes(invocation.parent, "identifier").First();
                    if (firstIdentifier.GetChild(0).GetText() == renamedItem.OriginalName)
                    {
                        CSIdentifierHelper.ChangeName(firstIdentifier, renamedItem.GeneratedName);
                    }
                }

                var typeUsage = TreeHelper.GetDescendantNodes(root, "type");
                foreach (var usage in typeUsage)
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

                var inheritanceUsage = TreeHelper.GetDescendantNodes(root, "class_base");
                foreach (var inheritance in inheritanceUsage)
                {
                    var classIdentifiers = TreeHelper.GetDescendantNodes(inheritance, "identifier");
                    if (classIdentifiers.Count() == 1)
                    {
                        var identifierNode = (CSParser.IdentifierContext)classIdentifiers.First();
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
