using System;
using System.Collections.Generic;
using System.Text;
using Voltaic;

namespace NRuneScape.GETracker
{
    public class SearchUsersParams : QueryMap
    {
        public string Name { get; set; }

        public Optional<string> Email { get; set; }


        public override IDictionary<string, string> CreateQueryMap()
        {
            var map = new Dictionary<string, string>
            {
                ["name"] = Name
            };

            if (Email.IsSpecified)
                map["email"] = Email.Value;

            return map;
        }
    }
}
