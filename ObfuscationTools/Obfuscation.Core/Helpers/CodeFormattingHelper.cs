using System;

namespace Obfuscation.Core.Helpers
{
    public static class CodeFormattingHelper
    {
        public static string CorrectCSFormatting(string source)
        {
            source = source.Replace(" . ", ".");
            source = source.Replace(" ;", ";" + Environment.NewLine);
            source = source.Replace("{", "{" + Environment.NewLine);
            source = source.Replace("}", Environment.NewLine + "}");
            source = source.Replace("<EOF>", "");
            source = source.Replace("namespace", Environment.NewLine + "namespace");

            return source;
        }
    }
}
