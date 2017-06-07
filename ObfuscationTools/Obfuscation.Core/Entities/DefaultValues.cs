using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Entities
{
    public static class DefaultValues
    {
        private static string identifiersBaseString = "identifier";
        private static int unrollingCount= 3;
        private static string cSharpConfigSectionName = "CSharpTransformationSettings";
        private static string cilConfigSectionName = "CilTransformationSettings";

        public static string IdentifiersBaseString { get { return identifiersBaseString; } }

        public static int UnrollingCount { get { return unrollingCount; } }

        public static string CSharpConfigSectionName { get { return cSharpConfigSectionName; } }

        public static string CilConfigSectionName { get { return cilConfigSectionName; } }
    }
}
