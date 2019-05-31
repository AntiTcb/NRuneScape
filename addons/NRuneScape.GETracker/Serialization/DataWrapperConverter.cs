using System;
using System.Reflection;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class DataWrapperConverter<T> : ValueConverter<DataWrapper<T>>
    {
        private readonly ValueConverter<T> _dataConverter;

        public DataWrapperConverter(Serializer serializer, PropertyInfo propInfo) 
            => _dataConverter = serializer.GetConverter<T>(propInfo, true);

        public override bool TryRead(ref ReadOnlySpan<byte> remaining, out DataWrapper<T> result, PropertyMap propMap = null)
        {
            result = default;

            if (!_dataConverter.TryRead(ref remaining, out var data, propMap))
                return false;

            result = new DataWrapper<T>(data);
            return true;
        }

        public override bool TryWrite(ref ResizableMemory<byte> writer, DataWrapper<T> value, PropertyMap propMap = null) 
            => throw new NotSupportedException();
    }
}
