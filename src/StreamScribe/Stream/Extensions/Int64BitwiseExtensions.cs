using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class Int64BitwiseExtensions
{
    public static long ClearBit(this long @this, int position)
    {
        AssertPositionInRange(position);
        @this &= ~(1L << position);
        return @this;
    }

    public static long ClearFlag(this ref long @this, long flag)
    {
        @this &= ~flag;
        return @this;
    }

    public static long ExtractValue(this long @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 64);
        return CreateMask(amount) & (@this >> position);
    }

    public static bool HasFlag(this long @this, long flag)
    {
        return (@this & flag) == flag;
    }

    public static long InsertValue(this long @this, int position, long value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this long @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1L << position)) != 0;
    }

    public static long SetBit(this long @this, int position)
    {
        AssertPositionInRange(position);
        @this |= 1L << position;
        return @this;
    }

    public static long SetFlag(this long @this, long flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 64);
    }

    private static long CreateMask(int amount)
    {
        if (amount > 63)
            return ~0L;

        return (1L << amount) - 1;
    }
}
