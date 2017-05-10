using Obfuscation.Core.Configuration;
using Obfuscation.Core.Exceptions;
using Obfuscation.Core.Entities;

namespace Obfuscation.Core.Managers
{
    public class ConfigurationManager
    {
        private ObfuscatorConfigSection config = ObfuscatorConfigSection.GetConfig();

        public Setting Renaming
        {
            get
            {
                return GetSetting("renaming");
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

        public DetailedSetting ConstantStringsEncryption
        {
            get
            {
                return GetDetailedSetting("constant_strings_encryption");
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
            if (config == null || config.CSharpSettingsCollection == null || config.CSharpSettingsCollection.Count == 0)
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

        private DetailedSetting GetDetailedSetting(string transformationKey)
        {
            if (config == null || config.CSharpSettingsCollection == null || config.CSharpSettingsCollection.Count == 0)
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
                return new DetailedSetting(transformationKey, isEnabled, setting.Details);
            }
            else
            {
                throw new InvalidConfigurationException(transformationKey);
            }
        }

    }
}
