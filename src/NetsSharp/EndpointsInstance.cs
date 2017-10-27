namespace NetsSharp
{
    using System;

    internal class EndpointsInstance : IEndpoints
    {
        private readonly Uri _baseUri;

        public EndpointsInstance(Uri baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri Register => new UriBuilder(_baseUri) {Path = "/Netaxept/Register.aspx"}.Uri;
        public Uri Process => new UriBuilder(_baseUri) {Path = "/Netaxept/Process.aspx"}.Uri;
        public Uri Query => new UriBuilder(_baseUri) {Path = "/Netaxept/Query.aspx"}.Uri;
        public Uri Terminal => new UriBuilder(_baseUri) {Path = "/Terminal/default.aspx"}.Uri;
    }
}