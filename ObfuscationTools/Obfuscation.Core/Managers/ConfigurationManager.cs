using Obfuscation.Core.Configuration;
using Obfuscation.Core.Exceptions;
using Obfuscation.Core.Entities;

namespace Obfuscation.Core.Managers
{
    internal class ConfigurationManager
    {       
        private ObfuscatorConfigSection config = ObfuscatorConfigSection.GetConfig();

        public bool CSharpConfigExists()
        {
            if (config != null && config.CSharpSettingsCollection != null && config.CSharpSettingsCollection.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool CilConfigExists()
        {
            if (config != null && config.CILSettingsCollection != null && config.CILSettingsCollection.Count > 0)
            {
                return true;
            }

            return false;
        }

        public SettingWithParams Renaming
        {
            get
            {
                return GetCSharpSettingsWithParams("renaming");
            }
        }

        public Setting FunctionInlining
        {
            get
            {
                return GetCSharpSetting("function_inlining");
            }
        }

        public SettingWithParams LoopUnrolling
        {
            get
            {
                return GetCSharpSettingsWithParams("loop_unrolling");
            }
        }

        public Setting FunctionInterleaving
        {
            get
            {
                return GetCSharpSetting("function_interleaving");
            }
        }

        public Setting AddingRedundantCodeCS
        {
            get
            {
                return GetCSharpSetting("adding_redundant_code");
            }
        }

        public SettingWithParams ConstantStringsEncryption
        {
            get
            {
                return GetCSharpSettingsWithParams("constant_strings_encryption");
            }
        }

        public Setting AssociationIntoArray
        {
            get
            {
                return GetCSharpSetting("association_into_array");
            }
        }

        public Setting AddingBogusClasses
        {
            get
            {
                return GetCSharpSetting("adding_bogus_classes");
            }
        }

        public Setting ControlFlowRestructuring
        {
            get
            {
                return GetCilSetting("control_flow_restructuring");
            }
        }

        public Setting UsingUnconditionalTransition
        {
            get
            {
                return GetCilSetting("using_unconditional_transition");
            }
        }

        public Setting AddingUnreachableCode
        {
            get
            {
                return GetCilSetting("adding_unreachable_code");
            }
        }

        public Setting AddingRedundantCodeCIL
        {
            get
            {
                return GetCilSetting("adding_redundant_code");
            }
        }

        private Setting GetCSharpSetting(string transformationKey)
        {
            if (config == null ||
               (config.CSharpSettingsCollection == null && config.CILSettingsCollection == null) ||
               (config.CSharpSettingsCollection.Count == 0 && config.CILSettingsCollection.Count == 0))
            {
                throw new ConfigFormatException();
            }

            var setting = config.CSharpSettingsCollection[transformationKey];
            if (setting == null)
            {
                throw new MissingConfigParameterException(transformationKey);
            }

            bool isEnabled;
            if (bool.TryParse(setting.TransformationIsEnabled, out isEnabled))
            {
                return new Setting(transformationKey, isEnabled);
            }
            else
            {
                throw new InvalidConfigurationException(transformationKey);
            }
        }

        private Setting GetCilSetting(string transformationKey)
        {
            if (config == null ||
               (config.CSharpSettingsCollection == null && config.CILSettingsCollection == null) ||
               (config.CSharpSettingsCollection.Count == 0 && config.CILSettingsCollection.Count == 0))
            {
                throw new ConfigFormatException();
            }

            var setting = config.CILSettingsCollection[transformationKey];
            if (setting == null)
            {
                throw new MissingConfigParameterException(transformationKey);
            }

            bool isEnabled;
            if (bool.TryParse(setting.TransformationIsEnabled, out isEnabled))
            {
                return new Setting(transformationKey, isEnabled);
            }
            else
            {
                throw new InvalidConfigurationException(transformationKey);
            }
        }

        private SettingWithParams GetCSharpSettingsWithParams(string transformationKey)
        {
            if (config == null ||
               (config.CSharpSettingsCollection == null && config.CILSettingsCollection == null) ||
               (config.CSharpSettingsCollection.Count == 0 && config.CILSettingsCollection.Count == 0))
            {
                throw new ConfigFormatException();
            }

            var setting = config.CSharpSettingsCollection[transformationKey];
            if (setting == null)
            {
                throw new MissingConfigParameterException(transformationKey);
            }

            bool isEnabled;
            if (bool.TryParse(setting.TransformationIsEnabled, out isEnabled))
            {
                return new SettingWithParams(transformationKey, isEnabled, setting.Parameters);
            }
            else
            {
                throw new InvalidConfigurationException(transformationKey);
            }
        }
    }

}
