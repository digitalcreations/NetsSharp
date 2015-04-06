namespace NetsSharp
{
    using System;

    class EndpointsInstance : IEndpoints
    {
        private readonly Uri _baseUri;

        public EndpointsInstance(Uri baseUri)
        {
            this._baseUri = baseUri;
        }

        public Uri Register
        {
            get
            {
                return new UriBuilder(this._baseUri) { Path = "/Netaxept/Register.aspx" }.Uri;
            }
        }

        public Uri Process
        {
            get
            {
                return new UriBuilder(this._baseUri) { Path = "/Netaxept/Process.aspx" }.Uri;
            }
        }

        public Uri Query
        {
            get
            {
                return new UriBuilder(this._baseUri) { Path = "/Netaxept/Query.aspx" }.Uri;
            }
        }

        public Uri Terminal 
        {
            get
            {
                return new UriBuilder(this._baseUri) { Path = "/Terminal/default.aspx" }.Uri;
            }
        }
    }
}