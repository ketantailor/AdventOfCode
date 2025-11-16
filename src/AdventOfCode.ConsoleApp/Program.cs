using AdventOfCode;
using AdventOfCode.Core;


Log.Info("Advent of Code by Ketan Tailor");
Log.Info();

try
{
    await MainImpl();
}
catch(Exception ex)
{
    Log.Error(ex.ToString());
}

static async Task MainImpl()
{
    var argsObj = new Args(Environment.GetCommandLineArgs()[1..]);

    if (argsObj.ShowHelp)
    {
        argsObj.WriteHelp();
        return;
    }

    using var inputProvider = InputProvider.CreateFromEnvironmentVariable();
    var runner = new Runner(inputProvider);

    if (argsObj.RunAll)
    {
        await runner.RunAll(argsObj.Verify);
    }
    else
    {
        await runner.Run(argsObj.Year, argsObj.Day, argsObj.Verify);
    }
}
