using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class Int8BitwiseExtensions
{
    public static sbyte ClearBit(this sbyte @this, int position)
    {
        AssertPositionInRange(position);
        @this &= (sbyte)~(1 << position);
        return @this;
    }

    public static sbyte ClearFlag(this ref sbyte @this, sbyte flag)
    {
        @this &= (sbyte)~flag;
        return @this;
    }

    public static sbyte ExtractValue(this sbyte @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 8);
        return (sbyte)(CreateMask(amount) & (@this >> position));
    }

    public static bool HasFlag(this sbyte @this, sbyte flag)
    {
        return (@this & flag) == flag;
    }

    public static sbyte InsertValue(this sbyte @this, int position, sbyte value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= (sbyte)shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this sbyte @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1 << position)) != 0;
    }

    public static sbyte SetBit(this sbyte @this, int position)
    {
        AssertPositionInRange(position);
        @this |= (sbyte)(1 << position);
        return @this;
    }

    public static sbyte SetFlag(this sbyte @this, sbyte flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 8);
    }

    private static sbyte CreateMask(int amount)
    {
        if (amount > 7)
            return 0;

        return (sbyte)((1 << amount) - 1);
    }
}
