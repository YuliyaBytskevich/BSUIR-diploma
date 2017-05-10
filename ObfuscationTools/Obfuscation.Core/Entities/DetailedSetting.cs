using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Entities
{
    public class DetailedSetting: Setting
    {
        public string Details { get; private set; } 

        public DetailedSetting(string transformationName, bool isEnabled, string details): base(transformationName, isEnabled)
        {
            Details = details;
        }
    }
}
