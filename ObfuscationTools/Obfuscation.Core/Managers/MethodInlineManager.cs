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

                //check if we need to replace 'this' with instance variable
                var thisNodes = TreeHelper.GetDescendantNodesWithText(copy, "this");
                if (thisNodes != null && thisNodes.Count() > 0)
                {
                    var instanceVariableName = context.parent.GetChild(0).GetChild(0).GetText();
                    foreach (var thisNode in thisNodes)
                    {
                        var newIdentifier = new CSParser.IdentifierContext((ParserRuleContext)thisNode, Mappers.CSParserState.NameToIndex("identifier").First());
                        newIdentifier.AddChild(new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("identifier"), instanceVariableName)));
                        ((CSParser.ThisReferenceExpressionContext)thisNode).RemoveLastChild();
                        ((CSParser.ThisReferenceExpressionContext)thisNode).AddChild(newIdentifier);
                    }
                }

                // check if we need to replace argument names with their values
                if (context.ChildCount == 3)
                {
                    // argument values from invocation
                    var argumentRootNodes = TreeHelper.GetDescendantNodes(context, "argument");
                    if (argumentRootNodes != null && argumentRootNodes.Count() > 0)
                    {
                        //var argmentValuesAndTypes = new Dictionary<string, string>();
                        var argumentTerminals = new List<RuleContext>();
                        foreach (var node in argumentRootNodes)
                        {
                            var terminalParent = (RuleContext)TreeHelper.GetFirstTerminalNode(node).Parent;
                            //argmentValuesAndTypes.Add(terminal.GetText(), Mappers.CSParserState.IndexToName(((RuleContext)terminal.Parent).invokingState));
                            argumentTerminals.Add(TreeHelper.GetDeepCopy(terminalParent));
                        }

                        // argument names from declaration 
                        var argDeclarationNodes = TreeHelper.GetDescendantNodes(targetMethodNode, "arg_declaration");
                        var argumentNames = new List<string>();

                        if (argDeclarationNodes != null && argDeclarationNodes.Count() > 0)
                        {                         
                            foreach (var node in argDeclarationNodes)
                            {
                                var identifier = TreeHelper.GetDescendantNodes(node, "identifier").First().GetChild(0).GetText();
                                argumentNames.Add(identifier);
                            }

                            var identifiers = TreeHelper.GetDescendantNodes(copy, "primary_expression_start");
                            foreach (var identifier in identifiers)
                            {
                                if (!(identifier.GetChild(0) is ITerminalNode))
                                {
                                    var node = (RuleContext)identifier.GetChild(0);
                                    if (Mappers.CSParserState.NameToIndex("identifier").Contains(node.invokingState))
                                    {
                                        var text = identifier.GetChild(0).GetChild(0).GetText();
                                        if (argumentNames.Contains(text) && !Mappers.CSParserState.NameToIndex("member_access").Contains(identifier.invokingState))
                                        {
                                            var x = (CSParser.Primary_expression_startContext)identifier;
                                            x.RemoveLastChild();
                                             x.AddChild(argumentTerminals[argumentNames.IndexOf(text)]);

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
}
