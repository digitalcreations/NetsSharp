namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ValidationException : Exception
    {
        public ValidationException(XElement error)
            : base(error.Descendants("Message").First().Value)
        {
        }
    }
}