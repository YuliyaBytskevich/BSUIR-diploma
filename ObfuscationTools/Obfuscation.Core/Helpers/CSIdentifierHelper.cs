using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities;
using System.Linq;

namespace Obfuscation.Core.Helpers
{
    public static class CSIdentifierHelper
    {
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();
        
        public static string GetName(RuleContext identifier)
        {
            return TreeHelper.GetDescendantNodes(identifier, "identifier").First().GetChild(0).GetText();
        }

        public static void ChangeName(RuleContext identifier, string newName)
        {
            var newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), newName));
            ((CSParser.IdentifierContext)identifier).RemoveLastChild();
            ((CSParser.IdentifierContext)identifier).AddChild(newLeaf);
        }

        public static void ChangeName(RuleContext identifier, TerminalNodeImpl newTerminalNode)
        {
            ((CSParser.IdentifierContext)identifier).RemoveLastChild();
            ((CSParser.IdentifierContext)identifier).AddChild(newTerminalNode);
        }

        public static string GetIdetifierTypeName(RuleContext identifier)
        {
            string typeName = null;
            var primaryExpressionNode = (RuleContext)identifier.parent.parent;
            var instanceIdentifier = TreeHelper.GetDescendantNodes(primaryExpressionNode, "identifier").First().GetChild(0).GetText();
            var currentClassBody = TreeHelper.GetAncestorNode(identifier, "class_body");

            // try to find among arguments
            var argumentsNodes = TreeHelper.GetDescendantNodes(currentClassBody, "arg_declaration");
            foreach (var node in argumentsNodes)
            {
                if (node.GetChild(node.ChildCount - 1).GetChild(0).GetText() == instanceIdentifier)
                {
                    var argTypeIdentifierNodes = TreeHelper.GetDescendantNodes((RuleContext)node.GetChild(0), "identifier");
                    if (argTypeIdentifierNodes != null && argTypeIdentifierNodes.Count() > 0)
                    {
                        typeName = CSIdentifierHelper.GetCheckedName(argTypeIdentifierNodes.First().GetChild(0).GetText(), RenameItemType.Class);
                    }
                }
            }

            if (primaryExpressionNode.GetChild(0).GetChild(0).GetText() == "this")
            {
                var classIdentifier = TreeHelper.GetDescendantNodes(currentClassBody.parent, "identifier").First().GetChild(0).GetText();
                typeName = CSIdentifierHelper.GetCheckedName(classIdentifier, RenameItemType.Class);
            }

            // try to find among objects created in current class
            if (string.IsNullOrEmpty(typeName))
            {
                var creationNodes = TreeHelper.GetDescendantNodes(currentClassBody, "object_creation_expression");
                foreach (var node in creationNodes)
                {
                    var variableDeclaratorNode = TreeHelper.GetAncestorNode(node, "variable_declarator");
                    if (variableDeclaratorNode != null)
                    {
                        var variableIdentitfierNode = TreeHelper.GetDescendantNodes(variableDeclaratorNode, "identifier").First();
                        if (variableDeclaratorNode.GetChild(0).GetText() == instanceIdentifier)
                        {
                            var typeIdentifierNode = TreeHelper.GetDescendantNodes((RuleContext)node.parent, "identifier").First();
                            typeName = CSIdentifierHelper.GetCheckedName(typeIdentifierNode.GetChild(0).GetText(), RenameItemType.Class);
                        }
                    }

                    var localVariableDeclaratorNode = TreeHelper.GetAncestorNode(node, "local_variable_declarator");
                    if (localVariableDeclaratorNode != null)
                    {
                        var variableIdentitfierNode = TreeHelper.GetDescendantNodes(localVariableDeclaratorNode, "identifier").First();
                        if (localVariableDeclaratorNode.GetChild(0).GetText() == instanceIdentifier)
                        {
                            var typeIdentifierNode = TreeHelper.GetDescendantNodes((RuleContext)node.parent, "identifier").First();
                            typeName = CSIdentifierHelper.GetCheckedName(typeIdentifierNode.GetChild(0).GetText(), RenameItemType.Class);
                        }
                    }
                }
            }

            return typeName;
        }

        public static string GetCheckedName(RuleContext identifier)
        {
            var name = GetName(identifier);
            if (RenameTable.ContainsGenerated(name))
            {
                return RenameTable.GetOriginal(name);
            }
            else
            {
                return name;
            }
        }

        public static string GetCheckedName(RuleContext identifier, RenameItemType type)
        {
            var name = GetName(identifier);
            if (RenameTable.ContainsGenerated(name, type))
            {
                return RenameTable.GetOriginal(name, type);
            }
            else
            {
                return name;
            }
        }


        public static string GetCheckedName(string obfuscated)
        {
            if (RenameTable.ContainsGenerated(obfuscated))
            {
                return RenameTable.GetOriginal(obfuscated);
            }
            else
            {
                return obfuscated;
            }
        }

        public static string GetCheckedName(string obfuscated, RenameItemType type)
        {
            if (RenameTable.ContainsGenerated(obfuscated, type))
            {
                return RenameTable.GetOriginal(obfuscated, type);
            }
            else
            {
                return obfuscated;
            }
        }

        public static string GetHierarchicalLocation(CSParser.IdentifierContext context)
        {
            var result = "";

            // put in namespace
            var namespaceDeclarationNode = TreeHelper.GetAncestorNode(context, "namespace_declaration");
            if (namespaceDeclarationNode != null)
            {
                var namespaceIdentifierNodes = TreeHelper.GetDescendantNodes((RuleContext)namespaceDeclarationNode.GetChild(1), "identifier");
                if (namespaceIdentifierNodes != null && namespaceIdentifierNodes.Count() > 0)
                {
                    var fullNamespace = "";
                    var namespacePart = namespaceIdentifierNodes.First().GetChild(0).GetText();
                    fullNamespace += CSIdentifierHelper.GetCheckedName(namespacePart, RenameItemType.Namespace);

                    for (int i = 1; i < namespaceIdentifierNodes.Count(); i++)
                    {
                        namespacePart = namespaceIdentifierNodes.ElementAt(i).GetChild(0).GetText();
                        fullNamespace += "." + CSIdentifierHelper.GetCheckedName(namespacePart, RenameItemType.Namespace);
                    }
                    result += fullNamespace;
                }
            }

            // put in class
            var classDeclarationNode = TreeHelper.GetAncestorNode(context, "class_definition");
            if (classDeclarationNode != null)
            {
                var classIdentifierNodes = TreeHelper.GetDescendantNodes(classDeclarationNode, "identifier");
                if (classIdentifierNodes != null && classIdentifierNodes.Count() > 0)
                {
                    result += "." + CSIdentifierHelper.GetCheckedName(classIdentifierNodes.First().GetChild(0).GetText(), RenameItemType.Class);
                }
            }

            // put in method
            var methodDeclarationNode = TreeHelper.GetAncestorNode(context, "method_declaration");
            if (methodDeclarationNode != null)
            {
                var methodIdentifierNodes = TreeHelper.GetDescendantNodes(methodDeclarationNode, "identifier");
                if (methodIdentifierNodes != null && methodIdentifierNodes.Count() > 0)
                {
                    result += "." + CSIdentifierHelper.GetCheckedName(methodIdentifierNodes.First().GetChild(0).GetText(), RenameItemType.Method);
                }
            }

            return result;
        }
    }
}
