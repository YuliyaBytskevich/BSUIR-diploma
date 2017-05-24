using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities.CSharpIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class RedundantCodeManager
    {
        private static Random random = new Random();
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public static void TryToAddRedundantCode(ParserRuleContext context, Root rootContext)
        {
            if (context is CSParser.String_literalContext)
            {
                DivideStrings(context);
            }
        }

        private static void DivideStrings(ParserRuleContext context)
        {  
            string text = context.GetChild(0).GetText().Replace("\"", "");
            int numberOfParts = 0;
            if (text.Length > 3)
            {
                numberOfParts = random.Next(2, (text.Length / 2));
            }
            else
            {
                numberOfParts = 2;
            }

            int portion = text.Length / numberOfParts;
            var expression = new CSParser.Additive_expressionContext((ParserRuleContext)context.parent, Mappers.CSParserState.NameToIndex("additive_expression").First());
            var invocationState = Mappers.CSParserState.NameToIndex("string_literal").First();
            CSParser.String_literalContext newLiteralContext = null;
            string newString = null;
            for (int i = 0; i < numberOfParts - 1; i++)
            {
                newLiteralContext = new CSParser.String_literalContext(expression, invocationState);
                newString =  "\"" + text.Substring(i * portion, portion) + "\"";
                newLiteralContext.AddChild(new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("string"), newString)));
                expression.AddChild(newLiteralContext);
                expression.AddChild(new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("plus"), "+")));
            }

            newLiteralContext = new CSParser.String_literalContext(expression, invocationState);
            newString = "\"" + text.Substring((numberOfParts - 1) * portion) + "\"";
            newLiteralContext.AddChild(new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("string"), newString)));
            expression.AddChild(newLiteralContext);

            var parent = (ParserRuleContext)context.parent;
            parent.RemoveLastChild();
            parent.AddChild(expression);
        }
    }
}
