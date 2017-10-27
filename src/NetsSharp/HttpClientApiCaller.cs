namespace NetsSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Exceptions;
    using NotSupportedException = Exceptions.NotSupportedException;

    public class HttpClientApiCaller : IApiCaller
    {
        private readonly IDictionary<string, Func<XElement, Exception>> _exceptionFactories =
            new Dictionary<string, Func<XElement, Exception>>
            {
                {"AuthenticationException", el => new AuthenticationException(el.Value)},
                {"BBSException", el => new BBSException(el)},
                {"MerchantTranslationException", el => new MerchantTranslationException(el)},
                {"GenericError", el => new GenericErrorException(el)},
                {"ValidationException", el => new ValidationException(el)},
                {"SecurityException", el => new SecurityException()},
                {"QueryException", el => new QueryException()},
                {"NotSupportedException", el => new NotSupportedException()},
                {"UniqueTransactionIdException", el => new UniqueTransactionIdException(el)}
            };

        public async Task<TResponse> CallAsync<TResponse>(Uri endpoint)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(endpoint);
                var deserializer = new XmlSerializer(typeof(TResponse));
                var contentStream = await response.Content.ReadAsStreamAsync();
                var xml = XDocument.Load(contentStream);
                if (xml.Root.Name.LocalName == "Exception")
                {
                    var error = xml.Root.Descendants("Error").First();
                    var exceptionType = error.Attribute(XName.Get("type", "http://www.w3.org/2001/XMLSchema-instance"))
                        ?.Value;
                    if (_exceptionFactories.ContainsKey(exceptionType))
                    {
                        throw _exceptionFactories[exceptionType](error);
                    }
                    throw new Exception();
                }

                contentStream.Seek(0, SeekOrigin.Begin);
                return (TResponse) deserializer.Deserialize(contentStream);
            }
        }
    }
}