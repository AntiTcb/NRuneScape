using System.Collections.Generic;
using System.Text;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class ApiStatus
    {
        // TODO: enum
        [ModelProperty("status")]
        public string Status { get; set; }
        [ModelProperty("health")]
        public float Health { get; set; }
        [ModelProperty("updateFrequency")]
        public int UpdateFrequency { get; set; }
        [ModelProperty("msg")]
        public string Message { get; set; }
    }
}
