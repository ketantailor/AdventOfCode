namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
public class AocPuzzleAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;
}