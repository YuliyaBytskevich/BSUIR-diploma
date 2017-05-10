using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities.CSharpIdentifiers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    public static class RenameManager
    {
        public static void TryToRenameIdentifier(CSParser.IdentifierContext context, Root rootContext)
        {
            var identifier = GetConcreteTypedIdentifier(context, rootContext);
            if (identifier != null)
            {
                identifier.RenameOnDeclaration(context);
                identifier.RenameInUsage();
            }
        }

        private static Identifier GetConcreteTypedIdentifier(CSParser.IdentifierContext context, Root root)
        {
            // we can just check parent state
            if (Mappers.CSParserState.NameToIndex("qualified_identifier").Contains(context.parent.invokingState))
            {
                return new Namespace(root);
            }

            if (Mappers.CSParserState.NameToIndex("class_definition").Contains(context.parent.invokingState))
            {
                return new Class(root);
            }

            if (Mappers.CSParserState.NameToIndex("interface_definition").Contains(context.parent.invokingState))
            {
                return new Interface(root);
            }

            if (Mappers.CSParserState.NameToIndex("interface_member_declaration").Contains(context.parent.invokingState))
            {
                return new InterfaceMember(root);
            }

            if (Mappers.CSParserState.NameToIndex("constructor_declaration").Contains(context.parent.invokingState))
            {
                return new Constructor(root);
            }

            if (Mappers.CSParserState.NameToIndex("method_member_name").Contains(context.parent.invokingState))
            {
                return new Method(root);
            }

            if (Mappers.CSParserState.NameToIndex("local_variable_declarator").Contains(context.parent.invokingState))
            {
                return new LocalVariable(root);
            }

            if (Mappers.CSParserState.NameToIndex("arg_declaration").Contains(context.parent.invokingState))
            {
                return new Arg(root);
            }

            // we have to check whole payload
            if (HasMatchInPayload(Mappers.CSParserState.NameToIndex("field_declaration"), context.Payload.ToString()))
            {
                return new Field(root);
            }

            if (HasMatchInPayload(Mappers.CSParserState.NameToIndex("property_declaration"), context.Payload.ToString()))
            {
                return new Property(root);
            }

            if (HasMatchInPayload(Mappers.CSParserState.NameToIndex("local_constant_declaration"), context.Payload.ToString()))
            {
                return new LocalConstant(root);
            }

            if (HasMatchInPayload(Mappers.CSParserState.NameToIndex("constant_declaration"), context.Payload.ToString()))
            {
                return new Constant(root);
            }

            if (HasMatchInPayload(Mappers.CSParserState.NameToIndex("indexer_declaration"), context.Payload.ToString()))
            {
                return new Indexer(root);
            }

            return null;
        }

        private static bool HasMatchInPayload(IEnumerable<int> states, string payload)
        {
            var numbersRegex = new Regex(@"\d+");
            var payloadStates = numbersRegex.Matches(payload);
            foreach (var payloadState in payloadStates)
            {
                if (states.Contains(int.Parse(payloadState.ToString())))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
