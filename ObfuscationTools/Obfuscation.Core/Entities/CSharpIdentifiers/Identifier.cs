using System.Linq;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    public abstract class Identifier
    {
        protected Root root = null;
        protected RenameItem renamedItem = null;

        public Identifier(Root root)
        {
            this.root = root;
        }

        #region abstract
        public abstract RenameItem RenameOnDeclaration(CSParser.IdentifierContext context);

        public abstract void RenameInUsage();
        #endregion

        #region virtual
        protected virtual RenameItem RenameIdentifier(CSParser.IdentifierContext context, RenameItemType type)
        {
            string original = context.GetChild(0).GetText();
            string obfuscated = null;
            RenameItem renameItem = null;

            if (!RenameTable.ContainsGenerated(original))
            {
                if (RenameTable.ContainsOriginal(original, type))
                {
                    CSIdentifierHelper.ChangeName(context, RenameTable.GetGenerated(original, type));
                }
                else
                {
                    obfuscated = IdentifiersGenerator.Generate();
                    renameItem = new RenameItem(type, original, obfuscated, CSIdentifierHelper.GetHierarchicalLocation(context));
                    RenameTable.Add(renameItem);
                    CSIdentifierHelper.ChangeName(context,obfuscated);
                }

                return renameItem;
            }
            else
            {
                return RenameTable.GetItem(original, type);
            }
        }
        #endregion

        #region non-virtual
        protected void RenameInUsage(string originalName, string obfuscatedName, string location)
        {
            var identifiers = TreeHelper.GetDescendantNodes(root, "identifier");

            foreach (var identifier in identifiers)
            {
                if (identifier.GetChild(0).GetText() == originalName)
                {
                    if (!Mappers.CSParserState.NameToIndex("member_access").Contains(identifier.parent.invokingState))
                    {
                        CSIdentifierHelper.ChangeName(identifier, obfuscatedName);
                    }
                    else
                    {
                        string typeName = CSIdentifierHelper.GetIdetifierTypeName(identifier);
                        if (!string.IsNullOrEmpty(typeName))
                        {
                            // now find this class node
                            var classDefinitionNodes = TreeHelper.GetDescendantNodes(root, "class_definition");
                            var classNode = classDefinitionNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node, RenameItemType.Class) == typeName);
                            if (classNode != null)
                            {
                                // check class own members                                    
                                var membersNodes = TreeHelper.GetDescendantNodes(classNode, "class_member_declaration");
                                var neededMemberNode = membersNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node) == identifier.GetChild(0).GetText());
                                if (neededMemberNode != null)
                                {
                                    CSIdentifierHelper.ChangeName(identifier, obfuscatedName);
                                }
                                else
                                {
                                    // check base class members
                                    var baseClassNodes = TreeHelper.GetDescendantNodes(classNode, "class_base");
                                    if (baseClassNodes != null && baseClassNodes.Count() > 0)
                                    {
                                        var baseClassName = CSIdentifierHelper.GetCheckedName(TreeHelper.GetDescendantNodes(baseClassNodes.First(), "identifier").First().GetChild(0).GetText(), RenameItemType.Class);
                                        var neededBaseClassNode = classDefinitionNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node, RenameItemType.Class) == baseClassName);
                                        if (neededBaseClassNode != null)
                                        {
                                            membersNodes = TreeHelper.GetDescendantNodes(neededBaseClassNode, "class_member_declaration");
                                            neededMemberNode = membersNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node) == identifier.GetChild(0).GetText());
                                            if (neededMemberNode != null)
                                            {
                                                CSIdentifierHelper.ChangeName(identifier, obfuscatedName);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
