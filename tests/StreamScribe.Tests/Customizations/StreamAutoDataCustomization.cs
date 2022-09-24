using AutoFixture;

using StreamScribe.Stream;
using StreamScribe.Stream.Generic;

namespace StreamScribe.Tests.Customizations;

internal sealed class StreamAutoDataCustomization : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() => GetImmutableStream());
        fixture.Register(() => GetMutableStream());
    }

    private static IEnumerable<byte> CreateRandomContext()
    {
        var rng = new Random();
        var lst = new List<byte>();
        var length = rng.Next(byte.MaxValue, ushort.MaxValue);
        for (var i = 0; i < length; i++)
        {
            lst.Add((byte)rng.Next(byte.MaxValue));
        }

        return lst;
    }

    private static IImmutableStream GetImmutableStream()
    {
        var context = CreateRandomContext();
        return StreamBuilder
           .GetInstance()
           .WithContext(context)
           .BuildImmutableStream();
    }

    private static IMutableStream GetMutableStream()
    {
        return StreamBuilder
            .GetInstance()
            .BuildMutableStream();
    }
}
