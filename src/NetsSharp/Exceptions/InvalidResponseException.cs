namespace NetsSharp.Exceptions
{
    using System;
    using System.Collections.Generic;

    public class InvalidResponseException : Exception
    {
        public InvalidResponseException(IEnumerable<KeyValuePair<ResponseCodeField, ResponseCodeError>> errors) 
            :base("The response from Nets indicates failure. See Errors property for details.")
        {
            this.Errors = errors;
        }

        public IEnumerable<KeyValuePair<ResponseCodeField, ResponseCodeError>> Errors { get; private set; } 
    }
}