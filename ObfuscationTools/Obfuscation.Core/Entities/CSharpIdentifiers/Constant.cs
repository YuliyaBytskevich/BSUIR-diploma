﻿using Obfuscation.Core.CSharpAnalysis;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Entities.CSharpIdentifiers
{
    internal class Constant : Identifier
    {
        public Constant(Root root) : base(root) { }

        public override RenameItem RenameOnDeclaration(CSParser.IdentifierContext context)
        {
            renamedItem = RenameIdentifier(context, RenameItemType.Constant);
            return renamedItem;
        }

        public override void RenameInUsage()
        {
            if (renamedItem != null)
            {
                RenameInUsage(renamedItem.OriginalName, renamedItem.GeneratedName, renamedItem.Location);
            }
        }
    }
}
