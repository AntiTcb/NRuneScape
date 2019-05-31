using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct DataWrapper<T>
    {
        [ModelProperty("data")]
        public T Data { get; set; }

        public DataWrapper(T data) => Data = data;

        public static implicit operator DataWrapper<T>(T value) => new DataWrapper<T> { Data = value };
        public static explicit operator T(DataWrapper<T> value) => value.Data;
    }
}
