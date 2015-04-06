namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class BBSException : Exception
    {
        public BBSException(XElement error)
            : base(error.Descendants("Message").First().Value)
        {
        }
    }
}
