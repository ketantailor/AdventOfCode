namespace AdventOfCode.Core;

internal static class Utils
{
    internal static int ReadNextInt(ReadOnlySpan<char> input, ref int index)
    {
        if (index >= input.Length)
            return 0;

        Predicate<char> isWhitespace = c => c == '\n' || c == '\r' || c == ' ';

        // skip leading whitesapce
        while(true)
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
        while (!isWhitespace(c))
        {
            var d = c - (int)'0';
            rv = (rv * 10) + d;

            index++;
            if (index >= input.Length)
                break;

            c = input[index];
        }
        return rv;
    }
}
