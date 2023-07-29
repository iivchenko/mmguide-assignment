namespace Assignment.Question2;

public sealed class Solution1
{
    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void Run_WithLoop(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = new LinkedList<int>();

        foreach (var item in list)
        {
            actual.AddFirst(item);
        }

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void Run_WithLoopForward(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = new LinkedList<int>();
        var current = list.First;

        while (current != null)
        {
            actual.AddFirst(current.Value);

            current = current.Next;
        }

        // Assert
        actual
            .Should()
            .Equal(expected);
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void Run_WithLoopsBackwards(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = new LinkedList<int>();
        var current = list.Last;

        while (current != null)
        {
            actual.AddLast(current.Value);

            current = current.Previous;
        }

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