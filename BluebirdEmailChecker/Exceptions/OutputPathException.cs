using System;

namespace BluebirdEmailChecker.Exceptions
{
    class OutputPathException : Exception
    {
        public OutputPathException() : this("Output path not found.") { }

        public OutputPathException(string message) : base(message) { }
    }
}
