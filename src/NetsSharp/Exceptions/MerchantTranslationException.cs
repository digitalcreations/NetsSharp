namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class MerchantTranslationException : Exception
    {
        public MerchantTranslationException(XElement error)
            : base(error.Descendants("Message").First().Value)
        {
        }
    }
}