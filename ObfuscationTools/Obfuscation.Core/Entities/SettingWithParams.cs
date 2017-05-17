using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Entities
{
    internal class SettingWithParams: Setting
    {
        public List<string> Params { get; private set; } 

        public SettingWithParams(string transformationName, bool isEnabled, string parameters): base(transformationName, isEnabled)
        {
            if (string.IsNullOrEmpty(parameters)) // no data at all
            {
                Params = null;
            }
            else if (parameters.Contains(';')) // list of params that are divided by ;
            {
                Params = parameters.Split(';').Select(p => p.Trim()).ToList();
            }
            else // single parsm
            {
                Params = new List<string>();
                Params.Add(parameters);
            }
        }
    }
}
