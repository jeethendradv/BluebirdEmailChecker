using System;

namespace BluebirdEmailChecker.Exceptions
{
    public class DataConfigFileNotFoundException : Exception
    {
        public DataConfigFileNotFoundException() : base("Data.xml File not found.") { }
    }
}
