using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Obfuscation.Core.CSharpAnalysis;
using Obfuscation.Core.Entities.CSharpIdentifiers;
using Obfuscation.Core.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Root = Obfuscation.Core.CSharpAnalysis.CSParser.Compilation_unitContext;

namespace Obfuscation.Core.Managers
{
    internal static class ConstantStringsManager
    {
        private static CommonTokenFactory tokenFactory = new CommonTokenFactory();

        public static void TryToHideConstantString(ParserRuleContext context, Root rootContext)
        {
            var encoded = Base64Encode(context.GetChild(0).GetText());
            encoded = "\"" + encoded + "\"";

            var newLeaf = new TerminalNodeImpl(tokenFactory.Create(Mappers.CSToken.TypeNameToIndex("string"), GetDecodingMethodUsage(encoded)));
            ((CSParser.String_literalContext)context).RemoveLastChild();
            ((CSParser.String_literalContext)context).AddChild(newLeaf);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        //public static string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public static string GetDecodingMethodDeclaration()
        {
            string result = "";
            result += "namespace OTSPNS {";
            result += "public static class OTSP {";
            result += "public static string Decode(string base64EncodedData) {";
            result += "var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);";
            result += " return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);";
            result += "}}}";

            return result;
        }

        private static string GetDecodingMethodUsage(string encoded)
        {
            return "OTSPNS.OTSP.Decode(" + encoded + ")";
        }
    }
}
