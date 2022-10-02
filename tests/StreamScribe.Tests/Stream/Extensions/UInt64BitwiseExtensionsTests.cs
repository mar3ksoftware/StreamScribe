using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class UInt64BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_UInt64_Test(Random rng)
    {
        var position = rng.Next(sizeof(ulong));
        ulong initialValue = 0;
        ulong value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_UInt64_Test(Random rng)
    {
        var flag = (ulong)rng.Next(1, 2);
        ulong value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_UInt64_Test(Random rng)
    {
        var insertValue = (ulong)rng.Next(1, 2);
        var position = 0;
        ulong value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_UInt64_Test(Random rng)
    {
        var position = rng.Next(sizeof(ulong));
        ulong value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_UInt64_Test(Random rng)
    {
        var flag = (ulong)rng.Next(1, 2);
        ulong value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
