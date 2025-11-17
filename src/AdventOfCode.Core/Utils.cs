using System.Text;

namespace AdventOfCode.Core;

internal static class Utils
{
    internal static int ReadNextInt(ReadOnlySpan<char> input, ref int index)
    {
        static bool isWhitespace(char c) => c == '\n' || c == '\r' || c == ' ';
        static bool isDigit(char c) => c >= '0' && c <= '9';

        // skip leading whitespace
        while (true)
        {
            if (index >= input.Length)
                return -1;

            var i = input[index];

            if (isWhitespace(i))
                index++;
            else
                break;
        }

        var rv = 0;
        char c = input[index];

        if (!isDigit(c))  // no int found
            return -1;

        while (!isWhitespace(c))
        {
            if (!isDigit(c))
                break;

            var d = c - (int)'0';
            rv = (rv * 10) + d;

            index++;
            if (index >= input.Length)
                break;

            c = input[index];
        }
        return rv;
    }

    internal static string? ReadNextString(ReadOnlySpan<char> input, ref int index)
    {
        static bool isWhitespace(char c) => c == '\n' || c == '\r' || c == ' ';
        static bool isString(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');

        // skip leading whitespace
        while (true)
        {
            if (index >= input.Length)
                return null;

            var i = input[index];

            if (isWhitespace(i))
                index++;
            else
                break;
        }

        var builder = new StringBuilder();
        char c = input[index];

        if (!isString(c))  // no string found
            return null;

        while (!isWhitespace(c))
        {
            if (!isString(c))
                break;

            builder.Append(c);

            index++;
            if (index >= input.Length)
                break;

            c = input[index];
        }
        
        return builder.ToString();
    }
}
