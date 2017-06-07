using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obfuscation.Core.Exceptions
{
    public class MissingConfigurationException: Exception
    {
        public MissingConfigurationException() : base("App.config file contains no obfuscation settings. This is required section. Please, fill App.config file according to all requirements.  See the documentation here: https://github.com/YuliyaBytskevich/BSUIR-diploma") { }

        private static string exceptionTemplate = "App.config file contains no {0} section. This section is required for applying transformations. Please, fill App.config file according to all requirements.  See the documentation here: https://github.com/YuliyaBytskevich/BSUIR-diploma";

        public MissingConfigurationException(string section) : base(string.Format(exceptionTemplate, section)) { }

        public MissingConfigurationException(string section, Exception innerException) : base(string.Format(exceptionTemplate, section), innerException) { }
    }
}
