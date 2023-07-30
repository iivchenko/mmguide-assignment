namespace Assignment.Question1.Solution2;

// Notes:
// As I have very little context about Double and Animal lists
// and its method DoSomething, I am carefully propose 
// alternative solution (as it is not unit testable)
// to creating own list type but to use one from .NET
public static class EnumerableExtensions
{
    public static void DoSomething<T>(this IEnumerable<T> _, T item)
    {
        Console.WriteLine($"{(item is null ? "NULL" : item.ToString())}");
    }
}