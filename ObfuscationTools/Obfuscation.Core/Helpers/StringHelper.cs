namespace Obfuscation.Core.Helpers
{
    internal static class StringHelper
    {
        public static string FitLength(string source, int numOfCharacters, char fillingChar = ' ')
        {
            if (source.Length < numOfCharacters)
            {
                return (new string(fillingChar, numOfCharacters - source.Length) + source);
            }
            else if (source.Length > numOfCharacters)
            {
                return source.Substring(0, numOfCharacters);
            }

            return source;
        }
    }
}
