using System;
namespace NRuneScape
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    internal class RouteAttribute : Attribute
    {   
        public string Route { get; }

        public RouteAttribute(string route)
        {
            Route = route;
        }
    }
}
