using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class Int16BitwiseExtensions
{
    public static short ClearBit(this short @this, int position)
    {
        AssertPositionInRange(position);
        @this &= (short)~(1 << position);
        return @this;
    }

    public static short ClearFlag(this ref short @this, short flag)
    {
        @this &= (short)~flag;
        return @this;
    }

    public static short ExtractValue(this short @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 16);
        return (short)(CreateMask(amount) & (@this >> position));
    }

    public static bool HasFlag(this short @this, short flag)
    {
        return (@this & flag) == flag;
    }

    public static short InsertValue(this short @this, int position, short value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= (short)shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this short @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1 << position)) != 0;
    }

    public static short SetBit(this short @this, int position)
    {
        AssertPositionInRange(position);
        @this |= (short)(1 << position);
        return @this;
    }

    public static short SetFlag(this short @this, short flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 16);
    }

    private static short CreateMask(int amount)
    {
        if (amount > 15)
            return 0;

        return (short)((1 << amount) - 1);
    }
}
