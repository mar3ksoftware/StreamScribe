using StreamScribe.Stream.Exceptions;
using StreamScribe.Stream.Generic;

namespace StreamScribe.Stream;

public sealed class StreamBuilder : IStreamBuilder
{
    private StreamBuilder()
    {
    }

    private IEnumerable<byte>? Context { get; set; }

    public static IStreamBuilder GetInstance()
    {
        return new StreamBuilder();
    }

    public IImmutableStream BuildImmutableStream()
    {
        if (Context == null)
        {
            throw new ContextNullException($"{typeof(IImmutableStream)} requires initial {nameof(Context)} of {typeof(IEnumerable<byte>)} to be provided.");
        }
        return new ImmutableStream(Context);
    }

    public IMutableStream BuildMutableStream()
    {
        return Context == null ? new MutableStream() : new MutableStream(Context);
    }

    public IStreamBuilder WithContext(IEnumerable<byte> context)
    {
        Context = context;
        return this;
    }
}
