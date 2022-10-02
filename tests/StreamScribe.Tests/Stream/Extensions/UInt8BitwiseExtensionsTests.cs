using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_UInt8_Test(Random rng)
    {
        var position = (byte)rng.Next(sizeof(byte));
        byte initialValue = 0;
        byte value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_UInt8_Test(Random rng)
    {
        var flag = (byte)rng.Next(1, 2);
        byte value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_UInt8_Test(Random rng)
    {
        var insertValue = (byte)rng.Next(1, 2);
        var position = (byte)0;
        byte value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_UInt8_Test(Random rng)
    {
        var position = (byte)rng.Next(sizeof(byte));
        byte value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_UInt8_Test(Random rng)
    {
        var flag = (byte)rng.Next(1, 2);
        byte value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
