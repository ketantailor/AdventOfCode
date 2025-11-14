namespace AdventOfCode.Year2021;

[AocPuzzle("Binary Diagnostic", Solution1 = "2640986", Solution2 = "6822109")]
internal class Day03 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var lines = input
            .Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.Trim())
            .ToArray();

        var (gammaVal, epsilonVal) = CalculateGammaAndEpsilon(lines);
        var powerConsumption = gammaVal * epsilonVal;

        Console.WriteLine($"lines={lines.Length}, gamma={gammaVal}, epsilon={epsilonVal}, powerConsumption={powerConsumption}");

        var oxygen = CalculateOxygenGeneratorRating(lines);
        var co2 = CalculateCO2ScrubberRating(lines);
        var solution2 = oxygen * co2;

        Console.WriteLine($"oxygen={oxygen}, co2={co2}, solution2={solution2}");

        return new SolutionResult(powerConsumption.ToString(), solution2.ToString());
    }

    private static (int, int) CalculateGammaAndEpsilon(string[] reports)
    {
        var digits = reports.First().Length;

        var gamma = new char[digits];
        var epsilon = new char[digits];

        for (var d = 0; d < digits; d++)
        {
            var zeros = 0;
            var ones = 0;

            for (var i = 0; i < reports.Length; i++)
            {
                if (reports[i][d] == '0')
                    zeros++;
                if (reports[i][d] == '1')
                    ones++;
            }

            gamma[d] = zeros > ones ? '0' : '1';
            epsilon[d] = zeros < ones ? '0' : '1';
        }

        var gammaVal = ConvertToInt(gamma);
        var epsilonVal = ConvertToInt(epsilon);
        return (gammaVal, epsilonVal);
    }

    private static int CalculateOxygenGeneratorRating(string[] reports)
    {
        var digits = reports.First().Length;

        var filteredReports = new List<string>(reports);
        for (var d = 0; d < digits; d++)
        {
            if (filteredReports.Count <= 1)
                break;

            var zeros = new List<string>(filteredReports.Count);
            var ones = new List<string>(filteredReports.Count);

            foreach (var report in filteredReports)
            {
                if (report[d] == '0')
                    zeros.Add(report);
                else
                    ones.Add(report);
            }

            if (zeros.Count > ones.Count)
                filteredReports = zeros;
            else
                filteredReports = ones;
        }

        return ConvertToInt(filteredReports.Single());
    }

    private static int CalculateCO2ScrubberRating(string[] reports)
    {
        var digits = reports.First().Length;

        var filteredReports = new List<string>(reports);
        for (var d = 0; d < digits; d++)
        {
            if (filteredReports.Count <= 1)
                break;

            var zeros = new List<string>(filteredReports.Count);
            var ones = new List<string>(filteredReports.Count);

            foreach (var report in filteredReports)
            {
                if (report[d] == '0')
                    zeros.Add(report);
                else
                    ones.Add(report);
            }

            if (zeros.Count > ones.Count)
                filteredReports = ones;
            else
                filteredReports = zeros;
        }

        return ConvertToInt(filteredReports.Single());
    }

    private static int ConvertToInt(string s)
    {
        return ConvertToInt(s.ToCharArray());
    }

    private static int ConvertToInt(char[] chars)
    {
        var value = 0;
        for (var i = chars.Length - 1; i >= 0; i--)
        {
            if (chars[i] == '1')
                value += Pow(2, chars.Length - i - 1);
        }
        return value;
    }

    private static int Pow(int x, int y)
    {
        var result = 1;
        for (var i = 0; i < y; i++)
            result *= x;
        return result;
    }
}
