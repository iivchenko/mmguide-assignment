namespace Assignment.Question4.Solution1;

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
