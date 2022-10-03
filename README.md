## StreamScribe - Mutable and Immutable binary stream operations.

#### Contents:
* `IImmutableStream` - Stream with predefined `context`, usually it's used for read-only operations.
* `IMutableStream` - Stream without predefined `context`, used for read and write operations.
* `IInteractivePointer` - Used internally to keep track of the current pointer position for either the `IImmutableStream` or `IMutableStream`.
* `MemoryPartitioner` - Provides an easy way to 'cut' any `IEnumerable<byte>` into separate chunks.
* `MemoryChunk` - Is a `record struct` which contains data generated by `MemoryPartitioner`.

#### How to create streams:
To create `IImmutableStream` or `IMutableStream` we'll use the `IStreamBuilder` and it's implementation `StreamBuilder`.

`IMutableStream` without initial `context`:
```csharp
using (var stream = StreamBuilder.GetInstance().BuildMutableStream())
{
    stream.WriteUInt8(0xFF);
}
```
or with `context`:
```csharp
IEnumerable<byte> context = new byte[1024];
using (var stream = StreamBuilder.GetInstance().WithContext(context).BuildMutableStream())
{
    stream.WriteUInt8(0xFF);
}
```

Same goes for `IImmutableStream`:
```csharp
using (var stream = StreamBuilder.GetInstance().BuildImmutableStream())
{
   var foo = stream.ReadUInt8(0xFF);
}
```

With one exception, since `IImmutableStream` needs some kind of context to be provided.
`context` can be provided using `WithContext(IEnumerable<byte> context)`.
```csharp
IEnumerable<byte> context = new byte[1024];
using (var stream = StreamBuilder.GetInstance().WithContext(context).BuildImmutableStream())
{
    var foo = stream.ReadUInt8(0xFF);
}
```

### Using `MemoryPartitioner`:

```csharp
using (var stream = StreamBuilder.GetInstance().BuildMutableStream())
{
    stream.WriteBytes((IEnumerable<byte>)context);
    var chunks = MemoryPartitioner.GenerateChunks(100, stream);
}
```

The above code will generate X number of chunks, each up to 100 entries long.

Here a sample benchmarks data for random bytes:

|                            Method |       Mean |     Error |    StdDev |     Median | Completed Work Items | Lock Contentions |   Gen0 | Allocated |
|---------------------------------- |-----------:|----------:|----------:|-----------:|---------------------:|-----------------:|-------:|----------:|
|         Partitioner_10_Iterations |   324.5 ns |   5.31 ns |   4.97 ns |   323.6 ns |                    - |                - | 0.1097 |     344 B |
|   Partitioner_10_Iterations_Async | 1,728.9 ns |  17.24 ns |  16.13 ns | 1,725.5 ns |               1.0222 |           0.0000 | 0.2384 |     744 B |
|        Partitioner_100_Iterations |   909.7 ns |   4.89 ns |   3.82 ns |   910.1 ns |                    - |                - | 0.2317 |     728 B |
|  Partitioner_100_Iterations_Async | 2,429.3 ns |  21.02 ns |  18.63 ns | 2,425.9 ns |               1.0145 |                - | 0.3624 |    1128 B |
|       Partitioner_1000_Iterations | 6,288.2 ns | 120.92 ns | 118.76 ns | 6,294.8 ns |                    - |                - | 1.1063 |    3488 B |
| Partitioner_1000_Iterations_Async | 8,732.0 ns | 166.67 ns | 459.05 ns | 8,596.8 ns |               1.0056 |                - | 1.2665 |    3888 B |