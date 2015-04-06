namespace NetsSharp
{
    using System;

    public static class Endpoints
    {
        public static IEndpoints Live { get { return new EndpointsInstance(new Uri("https://epayment.nets.eu/")); } }
        public static IEndpoints Test { get { return new EndpointsInstance(new Uri("https://test.epayment.nets.eu/")); } }
    }
}