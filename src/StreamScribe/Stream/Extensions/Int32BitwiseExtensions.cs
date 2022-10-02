using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class Int32BitwiseExtensions
{
    public static int ClearBit(this int @this, int position)
    {
        AssertPositionInRange(position);
        @this &= ~(1 << position);
        return @this;
    }

    public static int ClearFlag(this ref int @this, int flag)
    {
        @this &= ~flag;
        return @this;
    }

    public static int ExtractValue(this int @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 32);
        return CreateMask(amount) & (@this >> position);
    }

    public static bool HasFlag(this int @this, int flag)
    {
        return (@this & flag) == flag;
    }

    public static int InsertValue(this int @this, int position, int value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this int @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1 << position)) != 0;
    }

    public static int SetBit(this int @this, int position)
    {
        AssertPositionInRange(position);
        @this |= 1 << position;
        return @this;
    }

    public static int SetFlag(this int @this, int flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 32);
    }

    private static int CreateMask(int amount)
    {
        if (amount > 31)
            return ~0;

        return (1 << amount) - 1;
    }
}
