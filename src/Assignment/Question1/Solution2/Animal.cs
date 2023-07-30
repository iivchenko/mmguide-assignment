namespace Assignment.Question1.Solution2;

public sealed partial class UnitTests
{
    private sealed record Animal(string Name, IEnumerable<string> Habitats)
    {
        public override string ToString()
        {
            return $"{Name} live in {string.Join(", ", Habitats ?? Enumerable.Empty<string>())}";
        }
    }
}
