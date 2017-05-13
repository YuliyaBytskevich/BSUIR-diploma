using Obfuscation.Core.CSharpAnalysis;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class InterfaceMember: Identifier
    {
        public InterfaceMember(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            return RenameIdentifier(context, RenameItemType.InterfaceMember);
        }

        public override void RenameInUsage()
        {
            // do nothing (method is here for polymorphism support)
        }
    }
}
