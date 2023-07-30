namespace Assignment.Question3.Solution1;

public static class Algorithm2
{
    // Complexity
    //   == (time): O(1)
    //   == (space): O(1)
    //   Hash (time): O(n)
    //   Hash (space): O(1)
    //   Calculation (time): O(1) + O(n) + O(n) = O(n)
    //   Calculation (spce): O(1) + O(1) + O(1) = O(1)
    public static bool AreAnagrams(string value1, string value2)
    {
        return
            value1.Length == value2.Length &&
            ToCharsHash(value1) == ToCharsHash(value2);
    }

    // Complexity
    //   Select (time): O(n)
    //   Select (space): O(n)
    //   Sum (time): O(n)
    //   Sum (space): O(1)
    //   GetHashCode (time): O(1)
    //   GetHashCode (space): O(1)
    //   Calculation (time): O(nO(1)) + O(n) = O(n)
    //   Calculation (space): O(nO(1)) + O(1) = O(n)
    private static int ToCharsHash(string value)
    {
        return
            value
                .Select(x => x.GetHashCode())
                .Sum();
    }
}