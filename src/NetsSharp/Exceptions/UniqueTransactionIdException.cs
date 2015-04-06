namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class UniqueTransactionIdException : Exception
    {
        public UniqueTransactionIdException(XElement error)
            : base(error.Descendants("Message").First().Value)
        {
        }
    }
}