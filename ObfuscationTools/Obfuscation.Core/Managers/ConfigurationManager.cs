using Obfuscation.Core.Configuration;
using Obfuscation.Core.Exceptions;
using Obfuscation.Core.Entities;

namespace Obfuscation.Core.Managers
{
    internal class ConfigurationManager
    {
        private ObfuscatorConfigSection config = ObfuscatorConfigSection.GetConfig();

        public SettingWithParams Renaming
        {
            get
            {
                return GetSettingsWithParams("renaming");
            }
        }

        public Setting FunctionInlining
        {
            get
            {
                return GetSetting("function_inlining");
            }
        }

        public Setting LoopUnrolling
        {
            get
            {
                return GetSetting("loop_unrolling");
            }
        }

        public Setting FunctionInterleaving
        {
            get
            {
                return GetSetting("function_interleaving");
            }
        }

        public Setting AddingRedundantCodeCS
        {
            get
            {
                return GetSetting("adding_redundant_code");
            }
        }

        public SettingWithParams ConstantStringsEncryption
        {
            get
            {
                return GetSettingsWithParams("constant_strings_encryption");
            }
        }

        public Setting AssociationIntoArray
        {
            get
            {
                return GetSetting("association_into_array");
            }
        }

        public Setting AddingBogusClasses
        {
            get
            {
                return GetSetting("adding_bogus_classes");
            }
        }

        public Setting ControlFlowRestructuring
        {
            get
            {
                return GetSetting("control_flow_restructuring");
            }
        }

        public Setting UsingUnconditionalTransition
        {
            get
            {
                return GetSetting("using_unconditional_transition");
            }
        }

        public Setting AddingUnreachableCode
        {
            get
            {
                return GetSetting("adding_unreachable_code");
            }
        }

        public Setting AddingRedundantCodeCIL
        {
            get
            {
                return GetSetting("adding_redundant_code");
            }
        }

        private Setting GetSetting(string transformationKey)
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
                throw new MissingConfigurationException(transformationKey);
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

        private SettingWithParams GetSettingsWithParams(string transformationKey)
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
                throw new MissingConfigurationException(transformationKey);
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
