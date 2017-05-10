using System.Configuration;

namespace Obfuscation.Core.Configuration
{
    [ConfigurationCollection(typeof(CSObfuscatorSetting))]
    public class CSObfuscatorSettingsCollection: ConfigurationElementCollection
    {
        public new CSObfuscatorSetting this[string responseString]
        {
            get
            {
                return (CSObfuscatorSetting)BaseGet(responseString);
            }

            set
            {
                if (this.BaseGet(responseString) != null)
                {
                    this.BaseRemoveAt(this.BaseIndexOf(this.BaseGet(responseString)));
                }

                this.BaseAdd(value);
            }
        }

        public CSObfuscatorSetting this[int index]
        {
            get
            {
                return BaseGet(index) as CSObfuscatorSetting;
            }

            set
            {
                if (this.BaseGet(index) != null)
                {
                    this.BaseRemoveAt(index);
                }

                this.BaseAdd(index, value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CSObfuscatorSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CSObfuscatorSetting)element).Transformation;
        }
    }
}
