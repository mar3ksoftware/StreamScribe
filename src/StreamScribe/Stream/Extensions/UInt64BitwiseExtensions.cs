using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class UInt64BitwiseExtensions
{
    public static ulong ClearBit(this ulong @this, int position)
    {
        AssertPositionInRange(position);
        @this &= ~(1UL << position);
        return @this;
    }

    public static ulong ClearFlag(this ref ulong @this, ulong flag)
    {
        @this &= ~flag;
        return @this;
    }

    public static ulong ExtractValue(this ulong @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 64);
        return CreateMask(amount) & (@this >> position);
    }

    public static bool HasFlag(this ulong @this, ulong flag)
    {
        return (@this & flag) == flag;
    }

    public static ulong InsertValue(this ulong @this, int position, ulong value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this ulong @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1UL << position)) != 0;
    }

    public static ulong SetBit(this ulong @this, int position)
    {
        AssertPositionInRange(position);
        @this |= 1UL << position;
        return @this;
    }

    public static ulong SetFlag(this ulong @this, ulong flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 64);
    }

    private static ulong CreateMask(int amount)
    {
        if (amount > 63)
            return ~0UL;

        return (1UL << amount) - 1;
    }
}
