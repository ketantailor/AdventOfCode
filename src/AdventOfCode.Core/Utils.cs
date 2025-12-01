using System.Runtime.CompilerServices;
using System.Text;

namespace AdventOfCode.Core;

internal static class Utils
{
    internal static int ReadNextInt(ReadOnlySpan<char> input, ref int index)
    {

        // skip leading whitespace
        while (true)
        {
            if (index >= input.Length)
                return -1;

            var i = input[index];

            if (IsWhitespace(i))
                index++;
            else
                break;
        }

        var rv = 0;
        char c = input[index];

        if (!IsDigit(c))  // no int found
            return -1;

        while (!IsWhitespace(c))
        {
            if (!IsDigit(c))
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

    internal static ReadOnlySpan<char> ReadNextString(ReadOnlySpan<char> input, ref int index)
    {
        // skip leading whitespace
        while (true)
        {
            if (index >= input.Length)
                return ReadOnlySpan<char>.Empty;

            var i = input[index];

            if (IsWhitespace(i))
                index++;
            else
                break;
        }

        //var builder = new StringBuilder();
        char c = input[index];

        if (!IsString(c))  // no string found
            return ReadOnlySpan<char>.Empty;

        var start = index;
        var end = index;
        while (!IsWhitespace(c))
        {
            if (!IsString(c))
                break;

            index++;
            end = index;

            if (index >= input.Length)
                break;

            c = input[index];
        }
        
        return input[start..end];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsWhitespace(char c) => c == '\n' || c == '\r' || c == ' ';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsDigit(char c) => c >= '0' && c <= '9';

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsString(char c) => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
}
