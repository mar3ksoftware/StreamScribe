namespace StreamScribe.Chunk;

/// <summary>
///     Chunk of bytes.
/// </summary>
/// <param name="Data">
///     Data for this chunk.
/// </param>
/// <param name="Position">
///     Offset of this chunk in the original data.
/// </param>
public record struct MemoryChunk(IEnumerable<byte> Data, int Position);
