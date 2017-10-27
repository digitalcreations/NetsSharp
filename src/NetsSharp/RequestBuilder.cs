namespace NetsSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class RequestBuilder
    {
        public Uri GetUri<T>(Uri endpoint, IDictionary<string, string> arguments, T options = default(T))
        {
            var ub = new UriBuilder(endpoint);
            var qb = new HttpQueryBuilder();
            foreach (var param in arguments)
            {
                qb.Add(param.Key, param.Value);
            }
            if (options != null)
            {
                var properties = typeof(T).GetRuntimeProperties().Where(p => p.CanRead)
                    .Where(p => (p.PropertyType != typeof(bool) && p.GetValue(options) != null) ||
                                (p.PropertyType == typeof(bool) && (bool) p.GetValue(options)))
                    .Select(p =>
                        new KeyValuePair<string, string>(
                            String.Format("{0}{1}", p.Name.Substring(0, 1).ToLowerInvariant(), p.Name.Substring(1)),
                            p.GetValue(options).ToString()))
                    .ToList();
                foreach (var kvp in properties)
                {
                    qb.Add(kvp.Key, kvp.Value);
                }
            }
            ub.Query = qb.ToString();
            return ub.Uri;
        }

        public Uri GetUri(Uri endpoint, IDictionary<string, string> arguments)
        {
            return GetUri(endpoint, arguments, (object) null);
        }
    }
}