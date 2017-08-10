using System;

namespace NRuneScape
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            var tokens = str.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                tokens[i] = token.Substring(0, 1).ToUpper() + token.Substring(1);
            }

            return string.Join(" ", tokens);
        }

        public static string[] Split(this string input, char separator, StringSplitOptions options)
            => input.Split(new[] { separator }, options);
    }
}