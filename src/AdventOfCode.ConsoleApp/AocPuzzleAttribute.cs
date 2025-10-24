namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
public class AocPuzzleAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;

    /// <summary>The solution for part 1. Required for the verify feature.</summary>
    public string? Solution1 {  get; set; }

    /// <summary>The solution for part 2. Required for the verify feature.</summary>
    public string? Solution2 {  get; set; }
}