namespace Assignment.Question4.Solution1;

public sealed class UnitTests
{
    [Fact]
    public void Where_ShouldReturnNodes_WhenPredicatesAreMatched()
    {
        // Arrange
        static bool HasOneChild<T>(TreeNode<T> node)
        {
            return node switch
            {
                (_, var left, null) => true,
                (_, null, var right) => true,
                _ => false
            };
        }

        static bool HasLeafChild<T>(TreeNode<T> node)
        {
            return node switch
            {
                (_, null, null) => false,
                (_, var left, var right) => 
                    left?.Left == null &&
                    left?.Right == null &&
                    right?.Left == null &&
                    right?.Right == null,
                _ => false
            };
        }

        var tree =
            AddNode(50,
                AddNode(17,
                    AddNode(9,
                        AddNode(14,
                            AddNode(12),
                            Empty<int>()),
                        Empty<int>()),
                    AddNode(23,
                        AddNode(19),
                        Empty<int>())),
                AddNode(76,
                    AddNode(54,
                        AddNode(72,
                            AddNode(67),
                            Empty<int>()),
                        Empty<int>()),
                    Empty<int>()));

        // Act
        var actual =
            tree
                .Where(HasOneChild)
                .Where(HasLeafChild)
                .Select(node => node.Value)
                .ToList();

        // Assert
        actual.Should().BeEquivalentTo(new[] { 14, 23, 72 });
    }

    private static TreeNode<T> AddNode<T>(T value, TreeNode<T>? left, TreeNode<T>? right)
    {
        return new TreeNode<T>(value, left, right);
    }

    private static TreeNode<T> AddNode<T>(T value)
    {
        return new TreeNode<T>(value, null, null);
    }

    private static TreeNode<T>? Empty<T>()
    {
        return null;
    }
}
