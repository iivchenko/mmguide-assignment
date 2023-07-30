using Moq;

namespace Assignment.Question1.Solution1;

public sealed partial class UnitTests
{
    private readonly Mock<IOutput> _output;

    public UnitTests()
    {
        _output =  new Mock<IOutput>();
    }

    [Fact]
    public void DoSomething_ShouldOutput_WhenDoubleListIsUsed()
    {
        // Arrange
        var value = 2.5;
        var doubles = new GenericList<double>(_output.Object);

        // Act
        doubles.DoSomething(value);

        // Assert
        _output.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void DoSomething_ShouldOutput_WhenAnimalListIsUsed()
    {
        // Arrange
        var animal = new Animal("Elefant", new List<string> { "Africa", "India" });
        var animals = new GenericList<Animal>(_output.Object);

        // Act
        animals.DoSomething(animal);

        // Assert
        _output.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
    }
}
