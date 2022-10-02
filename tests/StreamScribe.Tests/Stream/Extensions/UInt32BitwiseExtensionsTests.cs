using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class UInt32BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_UInt32_Test(Random rng)
    {
        var position = rng.Next(sizeof(uint));
        uint initialValue = 0;
        uint value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_UInt32_Test(Random rng)
    {
        var flag = (uint)rng.Next(1, 2);
        uint value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_UInt32_Test(Random rng)
    {
        var insertValue = (uint)rng.Next(1, 2);
        var position = 0;
        uint value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_UInt32_Test(Random rng)
    {
        var position = rng.Next(sizeof(uint));
        uint value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_UInt32_Test(Random rng)
    {
        var flag = (uint)rng.Next(1, 2);
        uint value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
