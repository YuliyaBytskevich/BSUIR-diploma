using System;

namespace Obfuscation.Core.Exceptions
{
    public class InvalidConfigurationException : Exception
    {
        private static string exceptionTemplate = "App.config file contains invalid value for {0} parameter. Required value: {1}. Please, update App.config file according to all requirements.";

        public InvalidConfigurationException(string configElementName) : base(CombineMessage(configElementName)) { }

        public InvalidConfigurationException(string configElementName, Exception innerException) : base(CombineMessage(configElementName), innerException) { }

        private static string CombineMessage(string configElementName)
        {
            var value = "";
            if (configElementName == "enabled")
            {
                value = "[true/false]";
            }
            else
            {
                value = "[see the documentation: https://github.com/YuliyaBytskevich/BSUIR-diploma]";
            }

            return string.Format(exceptionTemplate, configElementName, value);
        }
    }
}
