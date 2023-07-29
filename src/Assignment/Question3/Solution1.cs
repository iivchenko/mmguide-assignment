using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Assignment.Question3;

public sealed class Solution1
{
    private readonly ITestOutputHelper _output;

    public Solution1(ITestOutputHelper output)
    {
        _output = output;
    }

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

    [Fact]
    public void RunBanchmarks()
    {
        var logger = new AccumulationLogger();

        var config = 
            ManualConfig
                .Create(DefaultConfig.Instance)
                .AddLogger(logger)
                .WithOptions(ConfigOptions.DisableOptimizationsValidator);

        BenchmarkRunner.Run<SolutionBenchmarks>(config);

        _output.WriteLine(logger.GetLog());
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

        yield return new[] { new string(original),  new string(shuffled) }; 
    }

    [MemoryDiagnoser]
    public class SolutionBenchmarks
    {
        [ParamsSource(nameof(GetDataSource))]
        public string Value { get; set; }

        [Benchmark]
        public void RunAlgorithm1()
        {
            Algorithm1.AreAnagrams(Value, Value);
        }

        [Benchmark]
        public void RunAlgorithm2()
        {
            Algorithm2.AreAnagrams(Value, Value);
        }

        public IEnumerable<string> GetDataSource()
        {
            yield return "c";
            yield return "ca";
            yield return "car";
            yield return "short pharase";
            yield return "longer phrase is used here";
            yield return "that one is just long enought to calculate the meaning of life!!!";
        }
    }

    private sealed class Algorithm1
    {
        // Complexity
        //   == (time): O(1)
        //   == (space): O(1)
        //   Normalize (time): O(n)
        //   Normalize (space): O(n)
        //   Calculation (time): O(1) + O(n) + O(n) = O(n)
        //   Calculation (spce): O(1) + O(n) + O(n) = O(n)
        public static bool AreAnagrams(string value1, string value2)
        {
            return
                value1.Length == value2.Length &&
                Normalize(value1) == Normalize(value2);
        }

        // Complexity
        //   Order (time): O(1)
        //   Order (space): O(1)
        //   ToArray (time): O(n)
        //   ToArray (space): O(n)
        //   new (time): O(n)
        //   new (space): O(n)
        //   Calculation (time): O(1) + O(n) + O(n) = O(n)
        //   Calculation (space): O(1) + O(n) + O(n) = O(n)
        private static string Normalize(string value)
        {
            return new string(value.Order().ToArray());
        }
    }

    private sealed class Algorithm2
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
                Hash(value1) == Hash(value2);
        }

        // Complexity
        //   Select (time): O(1)
        //   Select (space): O(1)
        //   Sum (time): O(n)
        //   Sum (space): O(1)
        //   GetHashCode (time): O(1)
        //   GetHashCode (space): O(1)
        //   Calculation (time): O(1) + nO(1) + O(n) = O(n)
        //   Calculation (space): O(1) + nO(1) + O(1) = O(1)
        private static int Hash(string value)
        {
            return
                value
                    .Select(x => x.GetHashCode())
                    .Sum();
        }
    }
}