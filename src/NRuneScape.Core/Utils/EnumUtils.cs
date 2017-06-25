using System;
using System.Reflection;

namespace NRuneScape
{
    internal static class EnumUtils
    {
        public static string GetRoute<T>(T value) where T : struct
            => GetRoute<T, RouteAttribute>(value);
        public static string GetGERoute<T>(T value) where T : struct
            => GetRoute<T, GERouteAttribute>(value);
        public static string GetHiscoreRoute<T>(T value) where T : struct
            => GetRoute<T, HiscoreRouteAttribute>(value);

        internal static string GetRoute<TEnum, TAttr>(TEnum value) 
            where TEnum : struct
            where TAttr : RouteAttribute
        {
            if (!typeof(TEnum).GetTypeInfo().IsEnum)
                throw new ArgumentException($"{typeof(TEnum).Name} must be an enumerated type.");
            var routeInfo = value.GetAttribute<TEnum, TAttr>();
            return routeInfo.Route;
        }

        public static InfoAttribute GetInfo<T>(T value) where T : struct
        {
            var info = value.GetAttribute<T, InfoAttribute>();
            return info;
        }

        private static TAttr GetAttribute<TVal, TAttr>(this TVal value) where TVal : struct where TAttr : Attribute
        {
            if (!typeof(TVal).GetTypeInfo().IsEnum)
                throw new ArgumentException($"{nameof(TVal)} must be an enumerated type.");

            return value.GetType().GetRuntimeField(value.ToString()).GetCustomAttribute<TAttr>();
        }
    }
}
