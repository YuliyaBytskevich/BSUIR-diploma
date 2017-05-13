using System.Configuration;

namespace Obfuscation.Core.Configuration
{
    [ConfigurationCollection(typeof(CILObfuscatorSetting))]
    internal class CILObfuscatorSettingsCollection : ConfigurationElementCollection
    {
        public new CILObfuscatorSetting this[string responseString]
        {
            get
            {
                return (CILObfuscatorSetting)BaseGet(responseString);
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

        public CILObfuscatorSetting this[int index]
        {
            get
            {
                return BaseGet(index) as CILObfuscatorSetting;
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
            return new CILObfuscatorSetting();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((CILObfuscatorSetting)element).Transformation;
        }
    }
}
