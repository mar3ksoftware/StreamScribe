using System.Diagnostics;

namespace StreamScribe.Stream.Extensions;

public static class UInt16BitwiseExtensions
{
    public static ushort ClearBit(this ushort @this, int position)
    {
        AssertPositionInRange(position);
        @this &= (ushort)~(1 << position);
        return @this;
    }

    public static ushort ClearFlag(this ref ushort @this, ushort flag)
    {
        @this &= (ushort)~flag;
        return @this;
    }

    public static ushort ExtractValue(this ushort @this, int position, int amount)
    {
        AssertPositionInRange(position);
        Debug.Assert(amount > 0);
        Debug.Assert(amount + position <= 16);
        return (ushort)(CreateMask(amount) & (@this >> position));
    }

    public static bool HasFlag(this ushort @this, ushort flag)
    {
        return (@this & flag) == flag;
    }

    public static ushort InsertValue(this ushort @this, int position, ushort value)
    {
        AssertPositionInRange(position);
        var shiftedValue = value << position;
        Debug.Assert(shiftedValue >> position == value);
        @this |= (ushort)shiftedValue;
        return @this;
    }

    public static bool IsBitSet(this ushort @this, int position)
    {
        AssertPositionInRange(position);
        return (@this & (1 << position)) != 0;
    }

    public static ushort SetBit(this ushort @this, int position)
    {
        AssertPositionInRange(position);
        @this |= (ushort)(1 << position);
        return @this;
    }

    public static ushort SetFlag(this ushort @this, ushort flag)
    {
        @this |= flag;
        return @this;
    }

    [Conditional("DEBUG")]
    private static void AssertPositionInRange(int position)
    {
        Debug.Assert(position is >= 0 and < 16);
    }

    private static ushort CreateMask(int amount)
    {
        if (amount > 15)
            return 0;

        return (ushort)((1 << amount) - 1);
    }
}
