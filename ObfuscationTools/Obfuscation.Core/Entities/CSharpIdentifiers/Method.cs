using System.Linq;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;
using Antlr4.Runtime;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Method : Identifier
    {
        private List<string> ignoreMethods = new List<string>() { "Main", "ToString", "GetHashCode", "Equals", "GetType"};

        public Method(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            if (!ignoreMethods.Contains(context.GetChild(0).GetText()))
            {
                renamedItem = RenameIdentifier(context, RenameItemType.Method);
                return renamedItem;
            }
            return null;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                var methodInvocations = TreeHelper.GetDescendantNodes(root, "method_invocation");
                foreach (var invocation in methodInvocations)
                {
                    var identifiers = TreeHelper.GetDescendantNodes(invocation.parent, "identifier");
                    foreach (var identifier in identifiers)
                    {
                        if (identifier.GetChild(0).GetText() == renamedItem.OriginalName)
                        {
                            CSIdentifierHelper.ChangeName(identifier, renamedItem.GeneratedName);
                        }
                    }
                }
            }
        }

        protected override RenameItem RenameIdentifier(CSParser.IdentifierContext context, RenameItemType type)
        {
            CommonTokenFactory tokenFactory = new CommonTokenFactory();
            TerminalNodeImpl newLeaf = null;
            string original = context.GetChild(0).GetText();
            string obfuscated = null;
            RenameItem renameItem = null;

            if (!RenameTable.ContainsGenerated(original))
            {
                var classDefinitionNode = TreeHelper.GetAncestorNode(context, "class_definition");
                var inheritanceNodes = TreeHelper.GetDescendantNodes(classDefinitionNode, "class_base").Concat(TreeHelper.GetDescendantNodes(classDefinitionNode, "interface_base"));
                var interfaceDefinitions = TreeHelper.GetDescendantNodes(root, "interface_definition");

                if (interfaceDefinitions != null && interfaceDefinitions.Count() > 0)
                {
                    foreach (var inheritanceNode in inheritanceNodes)
                    {
                        var baseIdentifier = CSIdentifierHelper.GetCheckedName(TreeHelper.GetDescendantNodes(inheritanceNode, "identifier").First().GetChild(0).GetText());
                        var definitions = interfaceDefinitions.Where(node => CSIdentifierHelper.GetCheckedName(TreeHelper.GetDescendantNodes(node, "identifier").First().GetChild(0).GetText()) == baseIdentifier);
                        if (definitions != null && definitions.Count() > 0)
                        {
                            var memberNodes = TreeHelper.GetDescendantNodes(definitions.First(), "interface_member_declaration");
                            foreach (var node in memberNodes)
                            {
                                var memberIdentifierNode = TreeHelper.GetDescendantNodes(node, "identifier").First();
                                if (original == CSIdentifierHelper.GetCheckedName(memberIdentifierNode.GetChild(0).GetText()))
                                {
                                    obfuscated = RenameTable.GetGenerated(original, RenameItemType.InterfaceMember);
                                    if (string.IsNullOrEmpty(obfuscated))
                                    {
                                        obfuscated = IdentifiersGenerator.Generate();
                                        renameItem = new RenameItem(RenameItemType.InterfaceMember, original, obfuscated, CSIdentifierHelper.GetHierarchicalLocation((CSParser.IdentifierContext)memberIdentifierNode));
                                        RenameTable.Add(renameItem);
                                    }

                                    newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), obfuscated));
                                }
                            }
                        }
                    }

                    if (newLeaf == null)
                    {
                        if (RenameTable.ContainsOriginal(original, RenameItemType.Method))
                        {
                            newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), RenameTable.GetGenerated(original, RenameItemType.Method)));
                        }
                        else
                        {
                            obfuscated = IdentifiersGenerator.Generate();
                            renameItem = new RenameItem(RenameItemType.Method, original, obfuscated, CSIdentifierHelper.GetHierarchicalLocation(context));
                            RenameTable.Add(renameItem);
                            newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), obfuscated));
                        }
                    }
                }
                else
                {
                    if (RenameTable.ContainsOriginal(original, RenameItemType.Method))
                    {
                        newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), RenameTable.GetGenerated(original, RenameItemType.Method)));
                    }
                    else
                    {
                        obfuscated = IdentifiersGenerator.Generate();
                        renameItem = new RenameItem(RenameItemType.Method, original, obfuscated, CSIdentifierHelper.GetHierarchicalLocation(context));
                        RenameTable.Add(renameItem);
                        newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), obfuscated));
                    }
                }

                CSIdentifierHelper.ChangeName(context, newLeaf);

                return renameItem;
            }
            else
            {
                return RenameTable.GetItem(original, type);
            }
        }
    }
}
