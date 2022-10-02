namespace StreamScribe.Chunk;

public static class MemoryPartitioner
{
    /// <summary>
    ///     Generates chunks with the specified size. Last chunk may be smaller if data is not aligned.
    /// </summary>
    /// <param name="chunkSize">
    ///     Size of a single chunk.
    /// </param>
    /// <param name="data">
    ///     Data to partition into chunks.
    /// </param>
    /// <returns>
    ///     Partitioned data.
    /// </returns>
    public static IEnumerable<MemoryChunk> GenerateChunks(int chunkSize, IEnumerable<byte> data)
    {
        return GenerateChunks(chunkSize, data.ToArray().AsMemory());
    }

    /// <summary>
    ///     Asynchronously generates chunks with the specified size. Last chunk may be smaller if
    ///     data is not aligned.
    /// </summary>
    /// <param name="chunkSize">
    ///     Size of a single chunk.
    /// </param>
    /// <param name="data">
    ///     Data to partition into chunks.
    /// </param>
    /// <returns>
    ///     Partitioned data.
    /// </returns>
    public static async Task<IEnumerable<MemoryChunk>> GenerateChunksAsync(int chunkSize, IEnumerable<byte> data)
    {
        return await Task.Run(() => GenerateChunks(chunkSize, data.ToArray().AsMemory()));
    }

    private static IEnumerable<MemoryChunk> GenerateChunks(int chunkSize, ReadOnlyMemory<byte> data)
    {
        var dataLength = data.Length;
        var chunkCount = dataLength / chunkSize;
        var lastChunkSize = dataLength % chunkSize;

        for (var i = 0; i < chunkCount; i++)
        {
            var chunkOffset = i * chunkSize;
            var chunk = data.Slice(chunkOffset, chunkSize);
            yield return new MemoryChunk(chunk.ToArray(), chunkOffset);
        }

        if (lastChunkSize <= 0)
            yield break;

        var lastChunkOffset = chunkCount * chunkSize;
        var lastChunk = data.Slice(lastChunkOffset, lastChunkSize);
        yield return new MemoryChunk(lastChunk.ToArray(), lastChunkOffset);
    }
}
