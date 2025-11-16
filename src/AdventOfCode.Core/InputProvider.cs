using System.Net;

namespace AdventOfCode.Core;

/// <summary>
/// Downloads and caches on disk the AoC inputs for a given day.
/// </summary>
public class InputProvider : IDisposable
{
    private readonly HttpClientHandler _handler;
    private readonly HttpClient _client;

    public InputProvider(string session)
    {
        if (string.IsNullOrWhiteSpace(session))
            throw new ArgumentException($"'{nameof(session)}' cannot be null or whitespace.", nameof(session));

        var container = new CookieContainer();
        container.Add(new Cookie
        {
            Name = "session",
            Domain = ".adventofcode.com",
            Value = session,
        });

        _handler = new HttpClientHandler()
        {
            CookieContainer = container,
            UseCookies = true,
        };

        _client = new HttpClient(_handler)
        {
            BaseAddress = new Uri("https://adventofcode.com/"),
        };
        _client.DefaultRequestHeaders.UserAgent.ParseAdd(".NET (github.com/ketantailor/AdventOfCode)");
    }

    public async Task<string> GetInput(int year, int day)
    {
        var filePath = Path.Combine(GetDownloadPath(year), $"{year:0000}-{day:00}");

        if (!Directory.Exists(GetDownloadPath(year)))
        {
            Directory.CreateDirectory(GetDownloadPath(year));
        }

        if (!File.Exists(filePath))
        {
            var content = await GetInputFromWeb(year, day);
            await File.WriteAllTextAsync(filePath, content);
        }

        var inputText = await File.ReadAllTextAsync(filePath);
        return inputText;
    }

    private async Task<string> GetInputFromWeb(int year, int day)
    {
        var requestUri = $"{year}/day/{day}/input";
        Log.Debug($"Downloading input `{requestUri}` ...");

        var response = await _client.GetAsync(requestUri);
        var input = await response
            .EnsureSuccessStatusCode()
            .Content.ReadAsStringAsync();
        return input;
    }

    public static string GetDownloadPath()
    {
        var path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.Create),
            "AdventOfCode",
            "Inputs");
        return path;
    }

    public static string GetDownloadPath(int year)
    {
        var path = Path.Combine(GetDownloadPath(), year.ToString("0000"));
        return path;
    }

    public void Dispose()
    {
        _handler.Dispose();
        _client.Dispose();
    }
}
