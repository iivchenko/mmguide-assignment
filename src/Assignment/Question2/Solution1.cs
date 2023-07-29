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

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void Run_WithRecursion(IEnumerable<int> input, IEnumerable<int> expected)
    {
        // Arrange
        // {1, 2, 3, 4 }
        // 1 | 1 + { 2, 3, 4} = { 1, 2, 3, 4}
        // 2 | 2 + { 3, 4} = { 2, 3, 4}
        // 3 | 3 + { 4 } = { 3, 4}
        // 4 | 4 + { } = { 4 }
        // * | { }
        LinkedList<int> ReverseInternal(LinkedListNode<int> rest)
        {
            switch (rest)
            {
                case null:
                    return new LinkedList<int>();

                case LinkedListNode<int> node:
                    var list = ReverseInternal(node.Next);
                    list.AddLast(node.Value);
                    return list;
            }
        }

        var list = new LinkedList<int>(input);

        // Act
        var actual = new LinkedList<int>(ReverseInternal(list.First));

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