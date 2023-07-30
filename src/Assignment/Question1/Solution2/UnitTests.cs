namespace Assignment.Question1.Solution2;

// Notes:
// This fixture doesn't contain tests but 
// only sample piece of code.
// I moved with UnitTests name to be consistent 
// with other solutions.
public sealed partial class UnitTests
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
}
