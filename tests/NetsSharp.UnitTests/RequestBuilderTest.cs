namespace NetsSharp.UnitTests
{
    using System;
    using System.Collections.Generic;
    using Xunit;
    using Models;

    public class RequestBuilderTest
    {
        public static IEnumerable<IEnumerable<object>> GetUriData
        {
            get
            {
                yield return new object[]
                {
                    new Uri("https://example.org"),
                    new Dictionary<string, string>
                    {
                        {"merchantId", "abc123"},
                        {"token", "foobar"},
                        {"amount", "100"},
                        {"currencyCode", "NOK"}
                    },
                    new RegisterOptions(),
                    new Uri(
                        "https://example.org/?amount=100&currencyCode=NOK&environmentLanguage=C%23&language=no_NO&merchantId=abc123&serviceType=B&terminalVat=0&token=foobar")
                };

                yield return new object[]
                {
                    new Uri("https://example.com"),
                    new Dictionary<string, string>
                    {
                        {"merchantId", "abc123"},
                        {"token", "foobar"},
                        {"amount", "200"},
                        {"currencyCode", "USD"}
                    },
                    new RegisterOptions
                    {
                        ServiceType = ServiceType.MerchantHosted,
                        TerminalVat = 100,
                        CustomerFirstName = "Vegard",
                        CustomerLastName = "Larsen"
                    },
                    new Uri(
                        "https://example.com/?amount=200&currencyCode=USD&customerFirstName=Vegard&customerLastName=Larsen&environmentLanguage=C%23&language=no_NO&merchantId=abc123&serviceType=M&terminalVat=100&token=foobar")
                };
            }
        }

        [Theory, MemberData("GetUriData")]
        public void GetUri(Uri endpoint, IDictionary<string, string> arguments, RegisterOptions request, Uri result)
        {
            var builder = new RequestBuilder();
            Assert.Equal(result, builder.GetUri(endpoint, arguments, request));
        }
    }
}