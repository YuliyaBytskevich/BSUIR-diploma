using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Entities
{
    public static class DefaultValues
    {
        public static string IdentifiersBaseString { get; } = "identifier";

        public static int UnrollingCount { get; } = 3;
    }
}
