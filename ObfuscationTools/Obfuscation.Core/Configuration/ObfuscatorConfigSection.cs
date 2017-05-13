using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Obfuscation.Core.Configuration
{
    internal class ObfuscatorConfigSection: ConfigurationSection
    {
        [ConfigurationProperty("CSharpTransformationSettings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CSObfuscatorSettingsCollection), AddItemName = "add")]
        public CSObfuscatorSettingsCollection CSharpSectionItems => (CSObfuscatorSettingsCollection)this["CSharpTransformationSettings"];

        public CSObfuscatorSettingsCollection CSharpSettingsCollection
        {
            get
            {
                object o = this["CSharpTransformationSettings"];
                return o as CSObfuscatorSettingsCollection;
            }
        }

        [ConfigurationProperty("CilTransformationSettings", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CILObfuscatorSettingsCollection), AddItemName = "add")]
        public CSObfuscatorSettingsCollection SectionItems => (CSObfuscatorSettingsCollection)this["CilTransformationSettings"];

        public CILObfuscatorSettingsCollection CILSettingsCollection
        {
            get
            {
                object o = this["CilTransformationSettings"];
                return o as CILObfuscatorSettingsCollection;
            }
        }

        public static ObfuscatorConfigSection GetConfig()
        {
            return (ObfuscatorConfigSection)ConfigurationManager.GetSection("ObfuscаtorConfigurations") ?? new ObfuscatorConfigSection();
        }
    }
}
