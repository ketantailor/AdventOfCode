using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode;

public class Args
{
    private readonly string[] _args;

    public Args(string[] args)
    {
        _args = args;

        ShowHelp = _args.Length == 0 || _args.Contains("-h") || _args.Contains("--help");

        if (!ShowHelp)
        {
            Session = GetArgValueAsString(_args, "session");

            var yearAndDay = _args.FirstOrDefault(a => !a.StartsWith("-"))
                ?? throw new ApplicationException("Year and Day must be specified.");

            var split = yearAndDay.Split('.');
            Year = int.Parse(split[0]);
            Day = int.Parse(split[1]);

            if (Year < 100) Year += 2000;
        }
    }

    public bool ShowHelp { get; private set; }

    /// <summary>
    /// Session token required to download input files.
    /// </summary>
    public string? Session { get; private set; }

    public int Day { get; private set; }
    public int Year { get; private set; }

    public void WriteHelp()
    {
        Log.Info("Usage: AdventOfCode.ConsoleApp YEAR.DAY [OPTIONS]");
        Log.Info("Example: AdventOfCode.ConsoleApp 2024.1 --session:123456789abcdef");
        Log.Info();
        Log.Info("  --session    Session token required to download the input files");
        Log.Info();
        Log.Info("Inputs are downloaded to: " + InputProvider.GetDownloadPath());
        Log.Info();
    }

    private static string? GetArgValueAsString(string[] args, string argName)
    {
        var argParam = args.FirstOrDefault(a => a.StartsWith($"--{argName}=") || a.StartsWith($"--{argName}:"));
        var argValue = argParam?.Split('=', ':').ElementAtOrDefault(1)?.Trim('"');
        return argValue;
    }
}
