namespace Assignment.Question3.Solution1;

// Notes:
// This algorithm is inefficient, I would not 
// use it in real system. I introduce this one
// to showcase how theoretical complexity 
// applies to practival metrics.
public static class Algorithm1
{
    // Complexity
    //   == (time): O(1)
    //   == (space): O(1)
    //   Normalize (time): O(nlog(n))
    //   Normalize (space): O(n)
    //   Calculation (time): O(1) + O(nlog(n)) + O(nlog(n)) = O(n)
    //   Calculation (spce): O(1) + O(n) + O(n) = O(n)
    public static bool AreAnagrams(string value1, string value2)
    {
        return
            value1.Length == value2.Length &&
            Normalize(value1) == Normalize(value2);
    }

    // Complexity
    //   Order (time): O(nlog(n)) (quick sort underneath)
    //   Order (space): O(n) (spotted several allocations in src)
    //   ToArray (time): O(n)
    //   ToArray (space): O(n)
    //   new string (time): O(n) (native buffer copy)
    //   new string (space): O(n) (native buffer copy)
    //   Calculation (time): O(nlog(n)) + O(n) + O(n) = O(nlog(n))
    //   Calculation (space): O(n) + O(n) + O(n) = O(n)
    private static string Normalize(string value)
    {
        return new string(value.Order().ToArray());
    }
}
