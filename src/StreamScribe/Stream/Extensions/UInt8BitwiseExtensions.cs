using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class UInt8BitwiseExtensions
{
    public static byte ClearBit(this byte @this, int position)
    {
        AssertPositionInRange(position);
        @this &= (byte)~(1 << position);
        return @this;
    }

    public static byte ClearFlag(this ref byte @this, byte flag)
    {
        @this &= (byte)~flag;
        return @this;
    }

    public static byte ExtractValue(this byte @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 8);
        return (byte)(CreateMask(amount) & (@this >> position));
    }

    public static bool HasFlag(this byte @this, byte flag)
    {
        return (@this & flag) == flag;
    }

    public static byte InsertValue(this byte @this, int position, byte value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= (byte)shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this byte @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1 << position)) != 0;
    }

    public static byte SetBit(this byte @this, int position)
    {
        AssertPositionInRange(position);
        @this |= (byte)(1 << position);
        return @this;
    }

    public static byte SetFlag(this byte @this, byte flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 8);
    }

    private static byte CreateMask(int amount)
    {
        if (amount > 7)
            return 0;

        return (byte)((1 << amount) - 1);
    }
}
