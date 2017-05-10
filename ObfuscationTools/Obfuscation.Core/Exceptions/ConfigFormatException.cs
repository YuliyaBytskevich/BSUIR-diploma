using System;

namespace Obfuscation.Core.Exceptions
{
    public class ConfigFormatException : Exception
    {
        public ConfigFormatException() : base("Wrong obfuscator settings section format (App.config file). Please, fill App.config file according to all requirements. See the documentation here: https://github.com/YuliyaBytskevich/BSUIR-diploma") { }

        public ConfigFormatException(Exception innerException) : base("Wrong obfuscator settings section format (App.config file). Please, fill App.config file according to all requirements. See the documentation here: https://github.com/YuliyaBytskevich/BSUIR-diploma", innerException) { }
    }
}
