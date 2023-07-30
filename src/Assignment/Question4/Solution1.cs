using FluentAssertions.Equivalency;

namespace Assignment.Question4;

public sealed class Solution1
{
    [Fact]
    public void Run()
    {
        // Arrange
        static bool Predicate<T>(TreeNode<T> node)
        {
            return node switch
            {
                (_, null, null) _ => false,
                (_, var left, null) _ when left.Left is null && left.Right is null => true,
                (_, null, var right) _ when right.Left is null && right.Right is null => true,
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
                .Where(Predicate)
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

public record TreeNode<T>(T Value, TreeNode<T>? Left, TreeNode<T>? Right);

public static class TreeExtensions
{
    public static IEnumerable<TreeNode<T>> Where<T>(this TreeNode<T> source, Func<TreeNode<T>, bool> predicate)
    {
        static IEnumerable<TreeNode<T>> WhereInternal(TreeNode<T>? node, Func<TreeNode<T>, bool> predicate, List<TreeNode<T>> acc)
        {
            switch (node)
            {
                case null:
                    return acc;

                case TreeNode<T> n:
                    if (predicate(n))
                    {
                        acc.Add(n);
                    }

                    acc.AddRange(WhereInternal(n.Left, predicate, new List<TreeNode<T>>()));
                    acc.AddRange(WhereInternal(n.Right, predicate, new List<TreeNode<T>>()));

                    return acc;
            };
        }

        return WhereInternal(source, predicate, new List<TreeNode<T>>());
    }
}
