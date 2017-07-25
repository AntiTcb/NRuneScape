using System;
using System.Diagnostics;
using Model = NRuneScape.API.RuneDateModel;

namespace NRuneScape.Rest
{     
    [DebuggerDisplay("{Value.TotalDays}")]
    public struct RuneDate 
    {
        public static DateTimeOffset Origin => DateTimeOffset.Parse("27 Feb 2002 00:00:00 GMT");

        /// <summary>
        /// RuneScape specific date system, starting from Feburary 27, 2002, <seealso cref="Origin"/>, the date membership was released.
        /// <para>Implicit conversions to <see cref="DateTime"/> and <see cref="DateTimeOffset"/> are available.</para>
        /// </summary>
        public static RuneDate Now => new RuneDate(DateTimeOffset.Now - Origin);
        public TimeSpan Value { get; }
                           
        internal RuneDate(DateTimeOffset dto)
            => Value = dto - Origin;
        internal RuneDate(TimeSpan span)
            => Value = span;
        internal RuneDate(Model model)  
            => Value = TimeSpan.FromDays(model.LastUpdated);

        internal DateTimeOffset ToDateTimeOffset()
            => Origin.Add(Value);

        public static implicit operator DateTimeOffset(RuneDate d)
            => d.ToDateTimeOffset();
        public static implicit operator DateTime(RuneDate d)
            => d.ToDateTimeOffset().DateTime;


    }
}
