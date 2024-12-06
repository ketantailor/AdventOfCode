namespace AdventOfCode;

public class Args
{
    private readonly string[] _args;

    public Args(string[] args)
    {
        _args = args;

        ShowHelp = _args.Length == 0 || _args.Contains("-h") || _args.Contains("--help");
        Verify = _args.Contains("--verify");

        if (!ShowHelp)
        {
            var yearAndDay = _args.FirstOrDefault(a => !a.StartsWith("-"))
                ?? throw new ApplicationException("Year and Day must be specified.");

            if (yearAndDay.Contains("."))
            {
                var split = yearAndDay.Split('.');
                Year = int.Parse(split[0]);
                Day = int.Parse(split[1]);
            }
            else
            {
                Year = int.Parse(yearAndDay);
            }

            if (Year < 100) Year += 2000;
        }
    }

    public bool ShowHelp { get; private set; }
    public bool Verify { get; private set; }

    public int? Day { get; private set; }
    public int Year { get; private set; }

    public void WriteHelp()
    {
        Log.Info("Usage: AdventOfCode.ConsoleApp YEAR.DAY [OPTIONS]");
        Log.Info("Example: AdventOfCode.ConsoleApp 2024.1");
        Log.Info();
        Log.Info("Inputs are downloaded to: " + InputProvider.GetDownloadPath());
        Log.Info();
    }
}
