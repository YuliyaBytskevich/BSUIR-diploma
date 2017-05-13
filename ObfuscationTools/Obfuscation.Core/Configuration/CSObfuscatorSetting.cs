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

        [ConfigurationProperty("details", DefaultValue = "", IsKey = true, IsRequired = false)]
        public string Details
        {
            get { return (string)this["details"]; }
            set { this["details"] = value; }
        }
    }
}
