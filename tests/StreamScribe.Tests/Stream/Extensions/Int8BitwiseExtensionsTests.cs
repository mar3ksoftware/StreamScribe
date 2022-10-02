using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class Int8BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_Int8_Test(Random rng)
    {
        var position = (sbyte)rng.Next(sizeof(sbyte));
        sbyte initialValue = 0;
        sbyte value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_Int8_Test(Random rng)
    {
        var flag = (sbyte)rng.Next(1, 2);
        sbyte value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_Int8_Test(Random rng)
    {
        var insertValue = (sbyte)rng.Next(1, 2);
        var position = (sbyte)0;
        sbyte value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_Int8_Test(Random rng)
    {
        var position = (sbyte)rng.Next(sizeof(sbyte));
        sbyte value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_Int8_Test(Random rng)
    {
        var flag = (sbyte)rng.Next(1, 2);
        sbyte value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
