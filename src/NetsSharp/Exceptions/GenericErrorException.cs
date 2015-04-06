namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class GenericErrorException : Exception
    {
        public GenericErrorException(XElement error)
            : base(error.Descendants("Message").First().Value)
        {
        }
    }
}