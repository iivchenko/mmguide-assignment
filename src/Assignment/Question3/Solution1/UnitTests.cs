namespace Assignment.Question3.Solution1;

public sealed class UnitTests
{
    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void RunAlgorithm1_ShouldReturnTrue_WhenAnagrams(string value1, string value2)
    {
        // Act
        var actual = Algorithm1.AreAnagrams(value1, value2);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData("car", "card")]
    [InlineData("arc", "card")]
    public void RunAlgorithm1_ShouldReturnFalse_WhenNotAnagrams(string value1, string value2)
    {
        // Act
        var actual = Algorithm1.AreAnagrams(value1, value2);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [MemberData(nameof(GetDataSource))]
    public void RunAlgorithm2_ShouldReturnTrue_WhenAnagrams(string value1, string value2)
    {
        // Act
        var actual = Algorithm2.AreAnagrams(value1, value2);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData("car", "card")]
    [InlineData("arc", "card")]
    public void RunAlgorithm2_ShouldReturnFalse_WhenNotAnagrams(string value1, string value2)
    {
        // Act
        var actual = Algorithm2.AreAnagrams(value1, value2);

        // Assert
        actual.Should().BeFalse();
    }

    public static IEnumerable<object[]> GetDataSource()
    {
        yield return new[] { "car", "car" };
        yield return new[] { "rac", "car" };
        yield return new[] { "arc", "car" };
        yield return new[] { "car", "rac" };
        yield return new[] { "car", "arc" };

        var original =
            Enumerable
                .Range(0, 100)
                .Select(_ => (char)Random.Shared.Next(255))
                .ToArray();

        var shuffled = original.OrderDescending().ToArray();

        yield return new[] { new string(original), new string(shuffled) };
    }
}
