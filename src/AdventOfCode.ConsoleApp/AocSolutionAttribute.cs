namespace AdventOfCode;

[AttributeUsage(AttributeTargets.Class)]
public class AocSolutionAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;
}