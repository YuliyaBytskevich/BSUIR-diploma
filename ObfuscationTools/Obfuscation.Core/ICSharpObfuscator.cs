using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core
{
    public interface ICSharpObfuscator
    {
        void ObfuscateCSharpCode(string cSharpFilePath);

        string RenameIdentifiers(string cSharpCode, string identifierBase = null);

        string InlineMethods(string cSharpCode, double inliningCoefficient = 1);

        string UnrollLoops(string cSharpCode, int unrollingCoefficient = 1);

        string InterleaveFuctions(string cSharpCode, int interleavesCount = 1);

        string AddRedundantCode(string cSharpCode, int redundantCodePercent = 10);

        string EncryptConstantStrings(string cSharpCode, string key = null);

        string AssociateVariables(string cSharpCode, IEnumerable<string> types = null);

        string AddBogusClasses(string cSharpCode, int bogusClassesCount = 1);

    }
}
