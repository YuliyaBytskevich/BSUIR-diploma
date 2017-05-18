using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Helpers;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Namespace: Identifier
    {
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public Namespace(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Namespace);
            return renamedItem;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                var usings = TreeHelper.GetDescendantNodes(root, "using_directive");
                foreach (var directive in usings)
                {
                    var namesaceOrType = directive.GetChild(1);
                    for (int i = 0; i < namesaceOrType.ChildCount; i++)
                    {
                        if (namesaceOrType.GetChild(i).ChildCount == 1)
                        {
                            if (namesaceOrType.GetChild(i).GetChild(0).GetText() == renamedItem.OriginalName)
                            {
                                var identifierNode = (CSParser.IdentifierContext)namesaceOrType.GetChild(i);
                                CSIdentifierHelper.ChangeName(identifierNode, renamedItem.GeneratedName);
                            }
                        }
                    }
                }

                // and also in string literals (for constant strings decoding mostly)
                var stringLiterals = TreeHelper.GetDescendantNodes(root, "string_literal");
                foreach (var literal in stringLiterals)
                {
                    if (literal.GetChild(0).GetText().Contains(renamedItem.OriginalName + "."))
                    {
                        var newLiteral = literal.GetChild(0).GetText().Replace(renamedItem.OriginalName, renamedItem.GeneratedName);
                        var newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("string_literal"), newLiteral));
                        ((CSParser.String_literalContext)literal).RemoveLastChild();
                        ((CSParser.String_literalContext)literal).AddChild(newLeaf);
                    }
                }
            }
        }
    }
}
