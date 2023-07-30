namespace Assignment.Question2.Solution1;

public sealed class UnitTests
{
    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void ReversWithForEachLoop_ShouldRevers_WhenHappyPath(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = Algorithms.ReversWithForEachLoop(list);

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void ReversWithLoopForward_ShouldRevers_WhenHappyPath(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = Algorithms.ReversWithLoopForward(list);

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void ReversWithLoopBackward_ShouldRevers_WhenHappyPath(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = Algorithms.ReversWithLoopBackward(list);

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void ReversWithRecursion_ShouldRevers_WhenHappyPath(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange 
        var list = new LinkedList<int>(input);

        // Act
        var actual = Algorithms.ReversWithRecursion(list);

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void ReversWithTailRecursion_ShouldRevers_WhenHappyPath(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange       
        var list = new LinkedList<int>(input);

        // Act
        var actual = Algorithms.ReversWithTailRecursion(list);

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    public static IEnumerable<object[]> GetDataSource()
    {
        yield return new[] { Array.Empty<int>(), Array.Empty<int>() };
        yield return new[] { new[] { 7 }, new[] { 7 } };
        yield return new[] { new[] { 7, 13 }, new[] { 13, 7 } };
        yield return new[] { new[] { 7, 13, 666, 69, 42 }, new[] { 42, 69, 666, 13, 7 } };
    }
}