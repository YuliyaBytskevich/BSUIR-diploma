using System.Configuration;

namespace Obfuscation.Core.Configuration
{
    internal class CSObfuscatorSetting : ConfigurationElement
    {
        [ConfigurationProperty("transformation", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Transformation
        {
            get { return (string)this["transformation"]; }
            set { this["transformation"] = value; }
        }

        [ConfigurationProperty("enabled", DefaultValue = "false", IsKey = false, IsRequired = true)]
        public string TransformationIsEnabled
        {
            get { return (string)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        [ConfigurationProperty("parameters", DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Parameters
        {
            get { return (string)this["parameters"]; }
            set { this["parameters"] = value; }
        }
    }
}
