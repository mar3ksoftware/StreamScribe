using BenchmarkDotNet.Running;

using StreamScribe.Benchmarks.Chunk;

namespace StreamScribe.Benchmarks;

public static class Program
{
    public static void Main(string[] args)
    {
        _ = BenchmarkRunner.Run(typeof(MemoryPartitionerBenchmarks).Assembly);
    }
}
