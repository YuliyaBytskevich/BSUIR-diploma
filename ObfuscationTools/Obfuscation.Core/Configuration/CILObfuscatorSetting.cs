using System.Configuration;

namespace Obfuscation.Core.Configuration
{
    public class CILObfuscatorSetting : ConfigurationElement
    {
        [ConfigurationProperty("transformation", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Transformation
        {
            get { return (string)this["transformation"]; }
            set { this["transformation"] = value; }
        }

        [ConfigurationProperty("enabled", DefaultValue = true, IsKey = false, IsRequired = true)]
        public bool TransformationIsEnabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }
    }
}
