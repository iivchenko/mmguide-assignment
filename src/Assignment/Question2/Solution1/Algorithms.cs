namespace Assignment.Question2.Solution1;

public static class Algorithms
{
    public static LinkedList<T> ReversWithForEachLoop<T>(LinkedList<T> list)
    {
        var actual = new LinkedList<T>();

        foreach (var item in list)
        {
            actual.AddFirst(item);
        }

        return actual;
    }

    public static LinkedList<T> ReversWithLoopForward<T>(LinkedList<T> list)
    {
        var actual = new LinkedList<T>();
        var current = list.First;

        while (current != null)
        {
            actual.AddFirst(current.Value);

            current = current.Next;
        }

        return actual;
    }

    public static LinkedList<T> ReversWithLoopBackward<T>(LinkedList<T> list)
    {
        var actual = new LinkedList<T>();
        var current = list.Last;

        while (current != null)
        {
            actual.AddLast(current.Value);

            current = current.Previous;
        }

        return actual;
    }

    public static LinkedList<T> ReversWithRecursion<T>(LinkedList<T> list)
    {
        // {1, 2, 3, 4 }
        // 1 | 1 + { 2, 3, 4} = { 1, 2, 3, 4 }
        // 2 | 2 + { 3, 4} = { 2, 3, 4 }
        // 3 | 3 + { 4 } = { 3, 4 }
        // 4 | 4 + { } = { 4 }
        // * | { }
        static LinkedList<T> ReverseInternal(LinkedListNode<T>? rest)
        {
            switch (rest)
            {
                case null:
                    return new LinkedList<T>();

                case LinkedListNode<T> node:
                    var acc = ReverseInternal(node.Next);
                    acc.AddLast(node.Value);
                    return acc;
            };
        }

        return ReverseInternal(list.First);
    }

    public static LinkedList<T> ReversWithTailRecursion<T>(LinkedList<T> list)
    {
        // { 1, 3, 3, 4 }
        // 1 + {} = { 1 }                   | { 4, 3, 2, 1 }
        // 2 + { 1 } = { 2, 1 }             | { 4, 3, 2, 1 }
        // 3 + { 2, 1 } = { 3, 2, 1 }       | { 4, 3, 2, 1 }
        // 4 + { 3, 2, 1 } = { 4, 3, 2, 1 } | { 4, 3, 2, 1 }
        static LinkedList<T> ReverseInternal(LinkedListNode<T>? rest, LinkedList<T> acc)
        {
            switch (rest)
            {
                case null:
                    return acc;

                case LinkedListNode<T> node:
                    acc.AddFirst(rest.Value);
                    return ReverseInternal(node.Next, acc);
            }
        }

        return ReverseInternal(list.First, new LinkedList<T>());
    }
}
