namespace Assignment.Question1;

public sealed class Solution2
{
    [Fact]
    public void Run()
    {
        var animals = new List<Animal>();
        var doubles = new List<double>();

        animals.DoSomething(null);
        animals.DoSomething(new Animal("Elefant", new List<string> { "Africa", "India" }));
        doubles.DoSomething(2.5);
    }

    private sealed record Animal(string Name, IEnumerable<string> Habitats)
    {
        public override string ToString()
        {
            return $"{Name} live in {string.Join(", ", Habitats ?? Enumerable.Empty<string>())}";
        }
    }
}

public static class Solution2EnumerableExtensions
{
    public static void DoSomething<T>(this IEnumerable<T> _, T item)
    {
        Console.WriteLine($"{(item is null ? "NULL" : item.ToString())}");
    }
}