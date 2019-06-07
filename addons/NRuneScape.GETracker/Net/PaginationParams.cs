using System;
using System.Collections;
using System.Collections.Generic;
using Voltaic;

namespace NRuneScape.GETracker
{
    public class PaginationParams : QueryMap
    {
        public Optional<int> Page { get; set; }

        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>();
            if (Page.IsSpecified)
                map["page"] = Page.Value.ToString();

            return map;
        }

        public void LoadQueryMap(IReadOnlyDictionary<string, string> map)
        {
            if (map.TryGetValue("page", out string str))
                Page = int.Parse(str);
        }
    }

    public abstract class QueryMap : IQueryMap
    {
        private IDictionary<string, string> _map = null;

        public abstract IDictionary<string, string> CreateQueryMap();
        private IDictionary<string, string> Map {
            get
            {
                if (_map == null)
                    _map = CreateQueryMap();
                return _map;
            }
        }

        // IDictionary
        string IDictionary<string, string>.this[string key] { get => Map[key]; set => throw new NotSupportedException(); }
        ICollection<string> IDictionary<string, string>.Keys => Map.Keys;
        ICollection<string> IDictionary<string, string>.Values => Map.Values;

        void IDictionary<string, string>.Add(string key, string value) => throw new NotSupportedException();
        bool IDictionary<string, string>.ContainsKey(string key) => Map.ContainsKey(key);
        bool IDictionary<string, string>.Remove(string key) => throw new NotSupportedException();
        bool IDictionary<string, string>.TryGetValue(string key, out string value) => Map.TryGetValue(key, out value);

        // ICollection
        int ICollection<KeyValuePair<string, string>>.Count => Map.Count;
        bool ICollection<KeyValuePair<string, string>>.IsReadOnly => true;
        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item) => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item) => throw new NotSupportedException();
        void ICollection<KeyValuePair<string, string>>.Clear() => throw new NotSupportedException();
        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item) => Map.Contains(item);
        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) => Map.CopyTo(array, arrayIndex);

        // IEnumerable
        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator() => Map.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Map.GetEnumerator();
    }

    internal interface IQueryMap : IDictionary<string, string> { }
}
