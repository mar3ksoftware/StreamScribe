using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class UInt16BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_UInt16_Test(Random rng)
    {
        var position = (ushort)rng.Next(sizeof(ushort));
        ushort initialValue = 0;
        ushort value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_UInt16_Test(Random rng)
    {
        var flag = (ushort)rng.Next(1, 2);
        ushort value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_UInt16_Test(Random rng)
    {
        var insertValue = (ushort)rng.Next(1, 2);
        var position = (ushort)0;
        ushort value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_UInt16_Test(Random rng)
    {
        var position = (ushort)rng.Next(sizeof(ushort));
        ushort value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_UInt16_Test(Random rng)
    {
        var flag = (ushort)rng.Next(1, 2);
        ushort value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
