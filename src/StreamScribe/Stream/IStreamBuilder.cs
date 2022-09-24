using StreamScribe.Stream.Generic;

namespace StreamScribe.Stream;

public interface IStreamBuilder
{
    IImmutableStream BuildImmutableStream();

    IMutableStream BuildMutableStream();

    IStreamBuilder WithContext(IEnumerable<byte> context);
}
