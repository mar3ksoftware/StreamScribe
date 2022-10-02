using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class UInt32BitwiseExtensions
{
    public static uint ClearBit(this uint @this, int position)
    {
        AssertPositionInRange(position);
        @this &= ~((uint)1 << position);
        return @this;
    }

    public static uint ClearFlag(this ref uint @this, uint flag)
    {
        @this &= ~flag;
        return @this;
    }

    public static uint ExtractValue(this uint @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 32);
        return CreateMask(amount) & (@this >> position);
    }

    public static bool HasFlag(this uint @this, uint flag)
    {
        return (@this & flag) == flag;
    }

    public static uint InsertValue(this uint @this, int position, uint value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this uint @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & ((uint)1 << position)) != 0;
    }

    public static uint SetBit(this uint @this, int position)
    {
        AssertPositionInRange(position);
        @this |= (uint)1 << position;
        return @this;
    }

    public static uint SetFlag(this uint @this, uint flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 32);
    }

    private static uint CreateMask(int amount)
    {
        if (amount > 31)
            return ~(uint)0;

        return ((uint)1 << amount) - 1;
    }
}
