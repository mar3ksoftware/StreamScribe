using StreamScribe.Stream.Extensions;
using StreamScribe.Tests.Attributes;

namespace StreamScribe.Tests.Stream.Extensions;

public sealed class Int64BitwiseExtensionsTests
{
    [Theory]
    [ScribeAutoData]
    public void ClearBit_Int64_Test(Random rng)
    {
        var position = rng.Next(sizeof(long));
        long initialValue = 0;
        long value = initialValue;
        value = value.SetBit(position);
        Assert.True(value.ClearBit(position) == initialValue);
    }

    [Theory]
    [ScribeAutoData]
    public void ClearFlag_Int64_Test(Random rng)
    {
        var flag = (long)rng.Next(1, 2);
        long value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.ClearFlag(flag) == 0);
    }

    [Theory]
    [ScribeAutoData]
    public void InsertValue_Int64_Test(Random rng)
    {
        var insertValue = (long)rng.Next(1, 2);
        var position = 0;
        long value = 0;
        value = value.InsertValue(position, insertValue);
        Assert.True(value.ExtractValue(position, 2) == insertValue);
    }

    [Theory]
    [ScribeAutoData]
    public void SetBit_Int64_Test(Random rng)
    {
        var position = rng.Next(sizeof(long));
        long value = 0;
        value = value.SetBit(position);
        Assert.True(value.IsBitSet(position));
    }

    [Theory]
    [ScribeAutoData]
    public void SetFlag_Int64_Test(Random rng)
    {
        var flag = (long)rng.Next(1, 2);
        long value = 0;
        value = value.SetFlag(flag);
        Assert.True(value.HasFlag(flag));
    }
}
