using System;

namespace Obfuscation.Core.Exceptions
{
    public class MissingConfigParameterException : Exception
    {
        private static string exceptionTemplate = "App.config file contains no definition for required parameter: {0}. Please, fill App.config file according to all requirements.";

        public MissingConfigParameterException(string configElementName) : base(string.Format(exceptionTemplate, configElementName)) { }

        public MissingConfigParameterException(string configElementName, Exception innerException) : base(string.Format(exceptionTemplate, configElementName), innerException) { }
    }
}
