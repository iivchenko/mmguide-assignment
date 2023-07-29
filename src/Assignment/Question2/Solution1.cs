namespace Assignment.Question2;

public sealed class Solution1
{
    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void Run_WithLoops(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        var list = new LinkedList<int>(input);

        // Act
        var actual = ReverseWithLoop(list);

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

    private static LinkedList<T> ReverseWithLoop<T>(LinkedList<T> list)
    {
        var newList = new LinkedList<T>();

        foreach (var item in list)
        {
            newList.AddFirst(item);
        }

        return newList;
    }
}