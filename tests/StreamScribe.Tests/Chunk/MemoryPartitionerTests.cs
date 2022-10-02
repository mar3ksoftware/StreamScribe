using StreamScribe.Chunk;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Chunk;

public sealed class MemoryPartitionerTests
{
    [Theory]
    [ScribeAutoData]
    public void GenerateChunks_Test(int size, IEnumerable<byte> source)
    {
        var chunks = MemoryPartitioner.GenerateChunks(size, source);
        Assert.NotEmpty(chunks);
    }

    [Theory]
    [ScribeAutoData]
    public async Task GenerateChunksAsync_Test(int size, IEnumerable<byte> source)
    {
        var chunks = await MemoryPartitioner.GenerateChunksAsync(size, source);
        Assert.NotEmpty(chunks);
    }
}
