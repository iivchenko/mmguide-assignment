namespace Assignment.Question1.Solution1;

public sealed record Animal(string Name, IEnumerable<string> Habitats)
{
    public override string ToString()
    {
        return $"{Name} live in {string.Join(", ", Habitats ?? Enumerable.Empty<string>())}";
    }
}