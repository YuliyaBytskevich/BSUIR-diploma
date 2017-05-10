using System;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.CSharpAnalysis
{
    public class IdentifiersVisitor : CSParserBaseVisitor<Root>
    {
        private Root result = new Root(null, -1);
        protected override Root DefaultResult { get { return result; } }
        private CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public override Root VisitCompilation_unit(Root context)
        {
            result = context;
            return VisitChildren(context);
        }

        public override Root VisitIdentifier(CSParser.IdentifierContext context)
        {
            //var leaf = FindMatchingLeaf(result, context);
            //if (leaf != null)
            //{
            //    leaf = new TerminalNodeImpl(tokenFactory.Create(420, "fuuu"));
            //}
            FindMatchingLeaf(result, context);

            


            //PrintPretty(result, "", true);

            return result;
        }

        private void FindMatchingLeaf(IParseTree root, RuleContext context)
        {
            if (root != null)
            {
                for (int i = 0; i < root.ChildCount; i++)
                {
                    if (root.GetChild(i).Payload == context.Payload)
                    {
                        var x = root.GetChild(i);
                        var y = x.GetChild(0);
                        
                        y = new TerminalNodeImpl(tokenFactory.Create(420, "a"));
                        var z = x.GetChild(0);
                        Console.WriteLine(result.ToStringTree() + "\n\n");
                        break;
                    }
                    else
                    {
                        FindMatchingLeaf(root.GetChild(i), context);
                    }
                }
            }
        }




        static void PrintPretty(IParseTree node, string indent, bool last)
        {
            Console.Write(indent);
            if (last)
            {
                Console.Write("\\-");
                indent += "  ";
            }
            else
            {
                Console.Write("|-");
                indent += "| ";
            }

            var text = node.ToString();

            if (text.Contains("["))
            {
                text = text.Replace("[", "");
                text = text.Replace("]", "");
                if (text != string.Empty)
                {
                    var stateCode = int.Parse(text.Split(' ').First());
                    //var stateName = CSharpParser.GetStateName(stateCode);
                    //if (stateName != null)
                    //{
                    //    text = "[" + stateName + "]";
                    //}
                    //else
                    //{
                    //}
                    text = stateCode.ToString();
                }
                else
                {
                    text = "";
                }
            }
            else
            {
                text = "\"" + text + "\"";
            }

            Console.WriteLine(text);
            for (int i = 0; i < node.ChildCount; i++)
            {
                PrintPretty(node.GetChild(i), indent, i == node.ChildCount - 1);
            }
        }





    }
}
