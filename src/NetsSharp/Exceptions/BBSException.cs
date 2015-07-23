namespace NetsSharp.Exceptions
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class BBSException : Exception
    {
        public BBSException(XElement error)
            : base(FindMessage(error))
        {
        }

        private static string FindMessage(XElement error)
        {
            var message = error.Descendants("Message").First().Value;
            if (error.Descendants("Result").Any())
            {
                var result = error.Descendants("Result").First();
                if (result.Descendants("ResponseText").Any())
                {
                    message += ": " + result.Descendants("ResponseText").First().Value;
                }
            }

            return message;
        }
    }
}
