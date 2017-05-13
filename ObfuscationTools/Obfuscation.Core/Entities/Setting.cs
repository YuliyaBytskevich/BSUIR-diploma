using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Entities
{
    internal class Setting
    {
        public string Transformation { get; private set; }

        public bool IsEnabled { get; private set; }

        public Setting(string transformationName, bool isEnabled)
        {
            Transformation = transformationName;
            IsEnabled = isEnabled;
        }
    }
}
