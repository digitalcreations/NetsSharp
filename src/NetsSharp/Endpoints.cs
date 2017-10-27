namespace NetsSharp
{
    using System;

    public static class Endpoints
    {
        public static IEndpoints Live => new EndpointsInstance(new Uri("https://epayment.nets.eu/"));
        public static IEndpoints Test => new EndpointsInstance(new Uri("https://test.epayment.nets.eu/"));
    }
}