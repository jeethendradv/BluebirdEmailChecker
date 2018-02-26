using System;

namespace BluebirdEmailChecker.Exceptions
{
    public class ValidationLimitExceededException : Exception
    {
        public ValidationLimitExceededException() : base("Validation limit exceeded, please try after sometime.") { }
    }
}
