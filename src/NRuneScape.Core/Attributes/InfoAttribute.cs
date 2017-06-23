using System;       
namespace NRuneScape
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class InfoAttribute : Attribute
    {
        /// <summary> The line number that this data point is located on in the API response. </summary>
        public int Index { get; }
        /// <summary> The full name for this value. </summary>
        public string Name { get; }

        /// <summary> Creates a new <see cref="InfoAttribute"/> with the specified index and name. </summary>
        public InfoAttribute(int index, string name = null)
        {
            Index = index;
            Name = name;
        }
    }
}
