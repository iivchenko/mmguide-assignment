using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Running;

namespace Assignment.Question2.Solution1;

[Trait("Category", "Performance")]
public sealed class PerformanceTests
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
        public LinkedList<int> Value { get; set; } = new();

        [Benchmark]
        public void ReversWithForEachLoop()
        {
            Algorithms.ReversWithForEachLoop(Value);
        }

        [Benchmark]
        public void ReversWithLoopForward()
        {
            Algorithms.ReversWithLoopForward(Value);
        }

        [Benchmark]
        public void ReversWithLoopBackward()
        {
            Algorithms.ReversWithLoopBackward(Value);
        }

        [Benchmark]
        public void ReversWithRecursion()
        {
            Algorithms.ReversWithRecursion(Value);
        }

        [Benchmark]
        public void ReversWithTailRecursion()
        {
            Algorithms.ReversWithTailRecursion(Value);
        }

        public IEnumerable<LinkedList<int>> GetDataSource()
        {
            yield return new LinkedList<int>(Array.Empty<int>());
            yield return new LinkedList<int>(new[] { 1 });
            yield return new LinkedList<int>(new[] { 1, 2 });
            yield return new LinkedList<int>(new[] { 1, 2, 3 });
            yield return new LinkedList<int>(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            yield return new LinkedList<int>(Enumerable.Range(0, 100));
        }
    }
}
