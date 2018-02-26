using System;

namespace BluebirdEmailChecker.Exceptions
{
    public class OpenAccountNavigationException : Exception
    {
        public OpenAccountNavigationException() : this("Script error, Unable to navigate to open account URL") { }
        public OpenAccountNavigationException(string message) : base(message) { }
    }
}
