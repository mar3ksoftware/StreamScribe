using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class Int32BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_Int32_Test(Random rng)
    {
        var position = rng.Next(sizeof(int));
        int initialValue = 0;
        int value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_Int32_Test(Random rng)
    {
        var flag = rng.Next(1, 2);
        int value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_Int32_Test(Random rng)
    {
        var insertValue = rng.Next(1, 2);
        var position = 0;
        int value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_Int32_Test(Random rng)
    {
        var position = rng.Next(sizeof(int));
        int value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_Int32_Test(Random rng)
    {
        var flag = rng.Next(1, 2);
        int value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
