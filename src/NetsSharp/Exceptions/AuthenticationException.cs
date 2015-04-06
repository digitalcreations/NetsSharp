namespace NetsSharp.Exceptions
{
    using System;

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message)
            : base(message)
        {
        }
    }
}