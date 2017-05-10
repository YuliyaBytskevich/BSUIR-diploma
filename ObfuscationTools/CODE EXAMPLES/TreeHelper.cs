using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObfuscationTools.Helpers
{
    public static class TreeHelper
    {
        public static RuleContext GetAncestorNode(RuleContext current, string requiredNodeState)
        {
            var requiredIndexes = Mappers.CSParserState.NameToIndex(requiredNodeState);
            var ancestor = current.parent;
            while (ancestor != null && !requiredIndexes.Contains(ancestor.invokingState))
            {
                ancestor = ancestor.parent;
            }

            return ancestor;
        }

        public static IEnumerable<RuleContext> GetDescendantNodes(RuleContext current, string requiredNodeState)
        {
            var requiredIndexes = Mappers.CSParserState.NameToIndex(requiredNodeState);
            List<RuleContext> nodes = new List<RuleContext>();

            return CheckChildren(nodes, current, requiredIndexes);
        }

        public static RuleContext GetRoot(RuleContext current)
        {
            RuleContext result = current;
            while (result.parent != null)
            {
                result = result.parent;
            }

            return result;
        }

        public static RuleContext FindDescendantIndentifierNode(RuleContext current, string identifierName)
        {
            RuleContext descendant = null;

            for (int i = 0; i < current.ChildCount; i++)
            {
                if (!(current.GetChild(i) is ITerminalNode))
                {
                    if (current.GetChild(i).ChildCount == 1)
                    {
                        if (current.GetChild(i).GetChild(0).GetText() == identifierName)
                        {
                            return (RuleContext)current.GetChild(i);
                        }
                    }
                    else
                    {
                        return FindDescendantIndentifierNode((RuleContext)current.GetChild(i), identifierName);
                    }
                }
            }

            return descendant;
        }

        private static IEnumerable<RuleContext> CheckChildren(List<RuleContext> result, RuleContext current, IEnumerable<int> requiredIndexes)
        {
            for (int i = 0; i < current.ChildCount; i++)
            {
                if (!(current.GetChild(i) is ITerminalNode))
                {
                    var descendant = (RuleContext)current.GetChild(i);
                    if (requiredIndexes.Contains(descendant.invokingState))
                    {
                        result.Add(descendant);
                    }
                    else
                    {
                        CheckChildren(result, descendant, requiredIndexes);
                    }
                }
            }

            return result;
        }
    }
}
