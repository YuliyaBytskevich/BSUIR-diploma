using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Linq;

namespace Obfuscation.Core.Helpers
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

            return CheckChildrenIndexes(nodes, current, requiredIndexes);
        }


        public static IEnumerable<RuleContext> GetDescendantNodesWithText(RuleContext current, string requredText)
        {
            List<RuleContext> nodes = new List<RuleContext>();

            return CheckChildrenText(nodes, current, requredText);
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

        private static IEnumerable<RuleContext> CheckChildrenIndexes(List<RuleContext> result, RuleContext current, IEnumerable<int> requiredIndexes)
        {
            if (current != null)
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
                            CheckChildrenIndexes(result, descendant, requiredIndexes);
                        }
                    }
                }               
            }

            return result;
        }

        private static IEnumerable<RuleContext> CheckChildrenText(List<RuleContext> result, RuleContext current, string requiredText)
        {
            if (current != null)
            {
                for (int i = 0; i < current.ChildCount; i++)
                {
                    if (!(current.GetChild(i) is ITerminalNode))
                    {
                        var descendant = (RuleContext)current.GetChild(i);
                        if (descendant.GetText() == requiredText)
                        {
                            result.Add(descendant);
                        }
                        else
                        {
                            CheckChildrenText(result, descendant, requiredText);
                        }
                    }
                }
            }

            return result;
        }

    }
}
