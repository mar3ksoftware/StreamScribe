using System.Runtime.CompilerServices;

#if DEBUG
[assembly: InternalsVisibleTo("StreamScribe.Tests")]
#endif

namespace StreamScribe.Stream.Generic;

internal sealed class MutableStream : ReadWriteContext, IMutableStream
{
    internal MutableStream(IEnumerable<byte> context) : base(context)
    {
    }

    internal MutableStream() : base(Array.Empty<byte>())
    {
    }

    public override object Clone()
    {
        var length = this.Count();
        Span<byte> buffer = stackalloc byte[length];
        for (var i = 0; i < length; i++)
        {
            buffer[i] = this[i];
        }
        return new MutableStream(buffer.ToArray());
    }
}
