using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities;
using Obfuscation.Core.Helpers;
using System.Linq;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class LoopUnrollingManager
    {
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public static void UnrollFor(RuleContext context, int offset)
        {
            if (context.ChildCount >= 5)
            {
                var limitationExpression = (RuleContext)context.GetChild(4);
                if (Mappers.CSParserState.NameToIndex("expression").Contains(limitationExpression.invokingState))
                {
                    var relationalExpressions = TreeHelper.GetDescendantNodes(limitationExpression, "relational_expression");
                    if (relationalExpressions != null)
                    {
                        var limitShiftExpression = (RuleContext)relationalExpressions.First().GetChild(relationalExpressions.First().ChildCount - 1);
                        // check if max counter value is literal
                        var literals = TreeHelper.GetDescendantNodes(limitShiftExpression, "literal");
                        if (literals != null && literals.Count() == 1)
                        {
                            var count = int.Parse(literals.First().GetChild(0).GetText());
                            var iterator = TreeHelper.GetDescendantNodes(context, "for_iterator").First();
                            var body = TreeHelper.GetDescendantNodes(context, "block").First();
                            var statements = TreeHelper.GetDescendantNodes(body, "statement");
                            var newStatementList = new CSParser.Statement_listContext((ParserRuleContext)context.Parent, Mappers.CSParserState.NameToIndex("statement_list").First());
                            for (int i = 0; i < count; i++)
                            {
                                foreach (var statement in statements)
                                {
                                    newStatementList.AddChild(TreeHelper.GetDeepCopy(statement));
                                }

                                newStatementList.AddChild(TreeHelper.GetDeepCopy(iterator));
                                newStatementList.AddChild(new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("semicolon"), ";")));
                            }

                            var parent = (ParserRuleContext)context.parent;
                            parent.RemoveLastChild();
                            parent.AddChild(newStatementList);
                        }
                    }
                }
            }

        }
    }
}
