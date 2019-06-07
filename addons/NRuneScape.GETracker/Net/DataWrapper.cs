using System.Collections.Generic;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct DataWrapper<T>
    {
        [ModelProperty("data")]
        public T Data { get; set; }
        [ModelProperty("meta")]
        public Optional<Dictionary<string, object>> MetaData { get; set; }

        public DataWrapper(T data, Dictionary<string, object> metaData = default)
        {
            Data = data;
            MetaData = metaData;
        }

        public static implicit operator DataWrapper<T>(T value) => new DataWrapper<T> { Data = value };
        public static explicit operator T(DataWrapper<T> value) => value.Data;
    }
}
