using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ObfuscationTools.Helpers
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
    }
}
