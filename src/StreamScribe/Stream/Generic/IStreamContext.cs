namespace StreamScribe.Stream.Generic;

public interface IStreamContext : IEnumerable<byte>, IEquatable<IStreamContext>, ICloneable, IDisposable
{
    byte this[int index] { get; }
}
