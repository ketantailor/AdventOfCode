using System.Text;

namespace AdventOfCode.Year2015;

[AocPuzzle("Perfectly Spherical Houses in a Vacuum", Solution1 = "2572", Solution2 = "2631")]
public class Day03 : ISolution
{
    public SolutionResult Solve(string input)
    {
        var part1 = GetHouseDeliveries(input).Count;
        var part2 = GetHouseDeliveriesForTwo(input).Count;
        return new SolutionResult(part1.ToString(), part2.ToString());
    }

    private static IDictionary<string, int> GetHouseDeliveries(string route)
    {
        var deliveries = new Dictionary<string, int>();
        deliveries.Add("0,0", 1);   // add first house

        var x = 0;
        var y = 0;

        foreach (var r in route)
        {
            switch (r)
            {
                case '>':
                    x++;
                    break;
                case '<':
                    x--;
                    break;
                case '^':
                    y++;
                    break;
                case 'v':
                    y--;
                    break;
            }

            var key = $"{x},{y}";
            if (!deliveries.ContainsKey(key))
            {
                deliveries.Add(key, 0);
            }

            deliveries[key]++;
        }

        return deliveries;
    }

    private static IDictionary<string, int> GetHouseDeliveriesForTwo(string route)
    {
        var (routeA, routeB) = SplitInput(route);
        var deliveriesA = GetHouseDeliveries(routeA);
        var deliveriesB = GetHouseDeliveries(routeB);
        var totalDeliveries = MergeDictionaries(deliveriesA, deliveriesB);
        return totalDeliveries;
    }

    private static (string a, string b) SplitInput(string input)
    {
        var builderA = new StringBuilder();
        var builderB = new StringBuilder();
        for (var i = 0; i < input.Length; i += 2)
        {
            builderA.Append(input[i]);
            builderB.Append(input[i + 1]);
        }
        return (builderA.ToString(), builderB.ToString());
    }

    private static IDictionary<string, int> MergeDictionaries(IDictionary<string, int> dictA, IDictionary<string, int> dictB)
    {
        var mergedDict = new Dictionary<string, int>(dictA);
        foreach (var kvp in dictB)
        {
            if (!mergedDict.ContainsKey(kvp.Key))
            {
                mergedDict.Add(kvp.Key, 0);
            }

            mergedDict[kvp.Key] += kvp.Value;
        }
        return mergedDict;
    }
}
