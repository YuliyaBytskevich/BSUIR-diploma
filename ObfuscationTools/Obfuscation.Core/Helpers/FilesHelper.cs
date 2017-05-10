using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Obfuscation.Core.Helpers
{
    public static class FilesHelper
    {
        public static string ReadFile(string path)
        {
            try
            {
                using (var reader = new StreamReader(path))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                // handle
            }

            return null;
        }

        public static void WriteToFile(string text, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(text);
                }
            }
            catch (Exception ex)
            {
                // handle
            }
        }

        public static string ReadSlnFile(string path)
        {
            var projectFilePathRegex = new Regex(@"(([A-Z]+[a-z]+)+\\)+([A-Z]+[a-z]+)+\.csproj");
            var slnFileContent = ReadFile(path);
           
            if (projectFilePathRegex.IsMatch(slnFileContent))
            {
                var projectFilePath = projectFilePathRegex.Matches(slnFileContent)[0].ToString();
                var slnFileName = Path.GetFileName(path);
                path = path.Replace(slnFileName, projectFilePath);

                return ReadCsprojFile(path);
            }

            return null;
        }

        public static string ReadCsprojFile(string path)
        {
            string result = "";
            var fileIncludesRegex = new Regex("Compile Include=\"[A-Z]*[a-z]+.cs\"");
            var directory = Path.GetDirectoryName(path);
            var cprojFileContent = ReadFile(path);   
            var includes = fileIncludesRegex.Matches(cprojFileContent);

            foreach (var include in includes)
            {
                var includeString = include.ToString();
                var fileName = includeString.Substring(includeString.IndexOf('"') + 1, includeString.LastIndexOf('"') - includeString.IndexOf('"') - 1);
                result += ReadFile(Path.Combine(directory, fileName.ToString()));
                result = ReplaceUsingDirectives(result);
            }

            return result;
        }

        private static string ReplaceUsingDirectives(string source)
        {
            List<string> usings = new List<string>();
            var usingDirectivesRegex = new Regex("using .*;");
            var usingDirectives = usingDirectivesRegex.Matches(source);
            foreach (var match in usingDirectives)
            {
                source = source.Replace(match.ToString(), "");
                if (!usings.Contains(match.ToString()))
                {
                    usings.Add(match.ToString());
                }
            }

            var resultUsings = "";
            foreach (var u in usings)
            {
                resultUsings += u + "\n";
            }

            return resultUsings + source;
        }
    }
}
