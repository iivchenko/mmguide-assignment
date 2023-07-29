namespace Assignment.Question4;

public sealed class Solution1
{
    [Fact]
    public void Run()
    {
        // Arrange
        var tree = 
            AddNode(50,
                AddNode(17,
                    AddNode(9,
                        AddNode(14,
                            AddNode(12))),
                    AddNode(23,
                        AddNode(19))),
                AddNode(76,
                    AddNode(54,
                        AddNode(72,
                            AddNode(67)))));

        // Act
        var actual = 
            tree
                .Where(node => !node.Children.Any())
                .Select(node => node.Value);

        // Assert
        actual.Should().BeEquivalentTo(new[] { 14, 23, 72 });
    }

    private static TreeNode<T> AddNode<T>(T value, params TreeNode<T>[] children)
    {
        return new TreeNode<T>(value, children);
    }
}

public record TreeNode<T>(T Value, TreeNode<T>[] Children);

public static class TreeExtensions
{
    public static IEnumerable<TreeNode<T>> Where<T>(this TreeNode<T> source, Func<TreeNode<T>, bool> predicate)
    {
        static IEnumerable<TreeNode<T>> WhereInternal(TreeNode<T> node, Func<TreeNode<T>, bool> predicate, List<TreeNode<T>> acc)
        {
            return node.Children switch
            {
                [] => acc,
                [var single] when predicate(single) => Enumerable.Append(acc, node),
                var children => children.SelectMany(child => WhereInternal(child, predicate, acc))
            };
        }

        return WhereInternal(source, predicate, new List<TreeNode<T>>());
    }
}