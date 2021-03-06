﻿using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace NRuneScape.API
{
    internal class RestDeserializer : BaseDeserializer
    {   
        public override T Deserialize<T>(string content, HttpResponseMessage response)
        {
            switch (typeof(T))
            {   
                case var i when i == typeof(ItemModel):
                    return DeserializeItem<T>(content);
                case var iArray when iArray == typeof(ItemModel[]):
                    return DeserializeItems<T>(content);

                default:
                    try
                    {
                        return JsonConvert.DeserializeObject<T>(content);
                    }
                    catch (Exception e)
                    {
                        throw new InvalidOperationException($"{typeof(T).Name} is not a supported deserializable type.", e);
                    }

            }
        }

        protected override T DeserializeCharacter<T>(string content, Uri requestUri)
        {
            throw new NotSupportedException();
        }
    }
}
