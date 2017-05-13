using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities;
using Obfuscation.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class MethodInlineManager
    {
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public static void Inline(CSParser.Method_invocationContext context, Root root)
        {
            if (Mappers.CSParserState.NameToIndex("member_access").Contains(((RuleContext)context.parent.GetChild(1)).invokingState))
            {
                var memberAccessNode = (RuleContext)context.parent.GetChild(1);
                var identifier = TreeHelper.GetDescendantNodes(memberAccessNode, "identifier").First();
                string typeName = CSIdentifierHelper.GetIdetifierTypeName(identifier);
                if (!string.IsNullOrEmpty(typeName))
                {
                    // now find this class node
                    var classDefinitionNodes = TreeHelper.GetDescendantNodes(root, "class_definition");
                    var classNode = classDefinitionNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node, RenameItemType.Class) == typeName);
                    if (classNode != null)
                    {
                        // check class own methods                                    
                        var methodsNodes = TreeHelper.GetDescendantNodes(classNode, "method_declaration");
                        var targetMethodNode = methodsNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node) == identifier.GetChild(0).GetText());
                        if (targetMethodNode != null)
                        {
                            ProcessMethodMatch(context, targetMethodNode);
                        }
                        else
                        {
                            // check base class members
                            var baseClassNodes = TreeHelper.GetDescendantNodes(classNode, "class_base");
                            if (baseClassNodes != null && baseClassNodes.Count() > 0)
                            {
                                var baseClassName = CSIdentifierHelper.GetCheckedName(TreeHelper.GetDescendantNodes(baseClassNodes.First(), "identifier").First().GetChild(0).GetText(), RenameItemType.Class);
                                var targetBaseClassNode = classDefinitionNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node, RenameItemType.Class) == baseClassName);
                                if (targetBaseClassNode != null)
                                {
                                    methodsNodes = TreeHelper.GetDescendantNodes(targetBaseClassNode, "method_declaration");
                                    targetMethodNode = methodsNodes.FirstOrDefault(node => CSIdentifierHelper.GetCheckedName(node) == identifier.GetChild(0).GetText());
                                    if (targetMethodNode != null)
                                    {
                                        ProcessMethodMatch(context, targetMethodNode);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private static void ProcessMethodMatch(CSParser.Method_invocationContext context, RuleContext targetMethodNode)
        {
            var returnType = targetMethodNode.parent.GetChild(0).GetText();
            if (returnType == "void")
            {
                var methodBlockNode = (RuleContext)TreeHelper.GetDescendantNodes(targetMethodNode, "block").First().GetChild(1); // body without brackets
                var copy = TreeHelper.GetDeepCopy(methodBlockNode);

                var statementNode = (CSParser.StatementContext)TreeHelper.GetAncestorNode(context, "statement");
                statementNode.RemoveLastChild();
                statementNode.AddChild(copy);

                // check if we need to replace 'this' with instance variable
                var thisNodes = TreeHelper.GetDescendantNodesWithText(copy, "this");
                if (thisNodes != null && thisNodes.Count() > 0)
                {
                    var instanceVariableName = context.parent.GetChild(0).GetChild(0).GetText();
                    foreach (var thisNode in thisNodes)
                    {
                        var newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), instanceVariableName));
                        ((CSParser.ThisReferenceExpressionContext)thisNode).RemoveLastChild();
                        ((CSParser.ThisReferenceExpressionContext)thisNode).AddChild(newLeaf);
                    }
                }

                // check if we need to replace argument names with their values
                IEnumerable<RuleContext> argumentsNodes = null;
                if (context.ChildCount == 3)
                {
                    argumentsNodes = TreeHelper.GetDescendantNodes(context, "argument");
                }





            }
        }
    }
}
