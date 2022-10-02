using BenchmarkDotNet.Attributes;

using StreamScribe.Chunk;

namespace StreamScribe.Benchmarks.Chunk;

[MemoryDiagnoser]
[ThreadingDiagnoser]
public class MemoryPartitionerBenchmarks
{
    [Benchmark]
    public void Partitioner_10_Iterations()
    {
        var data = GetParitionerSource(10);
        _ = MemoryPartitioner.GenerateChunks(data.size, data.source);
    }

    [Benchmark]
    public async Task Partitioner_10_Iterations_Async()
    {
        var data = GetParitionerSource(10);
        _ = await MemoryPartitioner.GenerateChunksAsync(data.size, data.source);
    }

    [Benchmark]
    public void Partitioner_100_Iterations()
    {
        var data = GetParitionerSource(100);
        _ = MemoryPartitioner.GenerateChunks(data.size, data.source);
    }

    [Benchmark]
    public async Task Partitioner_100_Iterations_Async()
    {
        var data = GetParitionerSource(100);
        _ = await MemoryPartitioner.GenerateChunksAsync(data.size, data.source);
    }

    [Benchmark]
    public void Partitioner_1000_Iterations()
    {
        var data = GetParitionerSource(1000);
        _ = MemoryPartitioner.GenerateChunks(data.size, data.source);
    }

    [Benchmark]
    public async Task Partitioner_1000_Iterations_Async()
    {
        var data = GetParitionerSource(1000);
        _ = await MemoryPartitioner.GenerateChunksAsync(data.size, data.source);
    }

    private static (int size, IEnumerable<byte> source) GetParitionerSource(int iterations)
    {
        var lst = new List<byte>();
        var rng = new Random();
        var size = iterations / 10;

        for (var i = 0; i < iterations; i++)
        {
            lst.Add((byte)rng.Next(byte.MaxValue));
        }

        return (size, lst);
    }
}
