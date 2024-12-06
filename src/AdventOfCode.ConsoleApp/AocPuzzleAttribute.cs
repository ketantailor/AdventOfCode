namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
public class AocPuzzleAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;

    public string? Solution1 {  get; set; }
    public string? Solution2 {  get; set; }
}