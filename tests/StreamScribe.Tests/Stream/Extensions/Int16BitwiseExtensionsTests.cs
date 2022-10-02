using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class Int16BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_Int16_Test(Random rng)
    {
        var position = (short)rng.Next(sizeof(short));
        short initialValue = 0;
        short value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_Int16_Test(Random rng)
    {
        var flag = (short)rng.Next(1, 2);
        short value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_Int16_Test(Random rng)
    {
        var insertValue = (short)rng.Next(1, 2);
        var position = (short)0;
        short value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_Int16_Test(Random rng)
    {
        var position = (short)rng.Next(sizeof(short));
        short value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_Int16_Test(Random rng)
    {
        var flag = (short)rng.Next(1, 2);
        short value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
