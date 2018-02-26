using System;

namespace BluebirdEmailChecker.Exceptions
{
    public class AccountFormFieldException : Exception
    {
        public AccountFormFieldException() : base("Unable to enter account data.") { }
    }
}
