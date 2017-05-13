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
        public static void UnrollFor(RuleContext context)
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
                        var literals = TreeHelper.GetDescendantNodes(limitShiftExpression, "literal");
                        if (literals != null && literals.Count() == 1)
                        {
                            var count = literals.First().GetChild(0).GetText();
                            //var x = 1;

                            //var copy = ContextCopiesHelper.GetDeepCopy(limitShiftExpression);
                            //var x = 1;

                        }
                    }
                }
            }

        }
    }
}
