using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Assignment.Question3.Solution1;

[Trait("Category", "Performance")]
public class PerformanceTests
{
    private readonly ITestOutputHelper _output;

    public PerformanceTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void Run()
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

    [MemoryDiagnoser]
    public class SolutionBenchmarks
    {
        [ParamsSource(nameof(GetDataSource))]
        public string Value { get; set; } = string.Empty;

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
}
