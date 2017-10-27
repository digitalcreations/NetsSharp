namespace NetsSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class HttpQueryBuilder
    {
        private readonly IList<KeyValuePair<string, string>> _values = new List<KeyValuePair<string, string>>();

        public void Add(string name, string value)
        {
            _values.Add(new KeyValuePair<string, string>(name, value));
        }

        public void Remove(string name)
        {
            var removable = _values.Where(kvp => kvp.Key == name);
            foreach (var item in removable)
            {
                _values.Remove(item);
            }
        }

        public override string ToString()
        {
            return string.Join("&", _values
                .OrderBy(kvp => kvp.Key)
                .Select(kvp => string.Format("{0}={1}", kvp.Key, Uri.EscapeDataString(kvp.Value))));
        }
    }
}