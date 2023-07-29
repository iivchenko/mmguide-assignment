namespace Assignment.Question1;

public sealed class Solution1
{
    private readonly ITestOutputHelper _output;

    public Solution1(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Run()
    {
        var output = new TestOutput(_output);
        var animals = new GenericList<Animal>(output);
        var doubles = new GenericList<double>(output);

        animals.DoSomething(new Animal("Elefant", new List<string> { "Africa", "India" }));
        doubles.DoSomething(2.5);
    }

    private interface IOutput
    {
        void Write(string value);
    }

    private sealed class TestOutput : IOutput
    {
        private readonly ITestOutputHelper _output;

        public TestOutput(ITestOutputHelper output)
        {
            _output = output;
        }

        public void Write(string message)
        {
            _output.WriteLine(message);
        }
    }

    private sealed class GenericList<T>
    {
        private readonly IOutput _output;

        public GenericList(IOutput output)
        {
            _output = output;
        }

        public void DoSomething(T item)
        {
            _output.Write($"{(item is null ? "NULL" : item.ToString())}{Environment.NewLine}");
        }
    }

    private sealed record Animal(string Name, IEnumerable<string> Habitats)
    {
        public override string ToString()
        {
            return $"{Name} live in {string.Join(", ", Habitats ?? Enumerable.Empty<string>())}";
        }
    }
}