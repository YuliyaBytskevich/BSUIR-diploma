using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core
{
    public interface ICilObfuscator
    {
        void ObfuscateCilCode(string exeFilePath);

        string RestructControlFlow(string cilCode);

        string AddRedundantCode(string cilCode);

        string AddUnreachableCode(string cilCode);

        string AddUnconditionalTransition(string cilCode);
    }
}
