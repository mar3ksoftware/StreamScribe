using StreamScribe.Stream.Generic;
using StreamScribe.Tests.Attributes;

using System.Buffers.Binary;
using System.Text;

namespace StreamScribe.Tests.Stream;

public sealed class IImmutableStreamTests
{
    [Theory]
    [ScribeAutoData]
    public void Clone_Test(IImmutableStream stream)
    {
        var clone = stream.Clone();
        Assert.IsType<ImmutableStream>(clone);
        Assert.Equal(stream, clone);
    }

    [Theory]
    [ScribeAutoData]
    public void Equals_Test(IImmutableStream stream)
    {
        var clone = stream.Clone();
        Assert.IsType<ImmutableStream>(clone);
        var result = stream.Equals((IImmutableStream)clone);
        Assert.True(result);
    }

    [Theory]
    [ScribeAutoData]
    public void MoveBy_Test(IImmutableStream stream, Random rng)
    {
        var size = stream.Count();
        var index = rng.Next(size - 1);
        var assertValue = stream[index];
        stream.MoveBy(index);
        Assert.Equal(assertValue, stream.ReadUInt8());
    }

    [Theory]
    [ScribeAutoData]
    public void MoveTo_Test(IImmutableStream stream, Random rng)
    {
        var size = stream.Count();
        var index = rng.Next(size - 1);
        var assertValue = stream[index];
        stream.MoveTo(index);
        Assert.Equal(assertValue, stream.ReadUInt8());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadBytes_Test(IImmutableStream stream, Random rng)
    {
        var size = stream.Count();
        var amount = rng.Next(size - 1);
        var bytes = stream.ReadBytes(amount);
        Assert.Equal(amount, bytes.Count());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadDoubleBigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        stream.ReadBytes(sizeof(double))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadDoubleBigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadDoubleBigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadDoubleLittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        stream.ReadBytes(sizeof(double))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadDoubleLittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadDoubleLittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt16BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        stream.ReadBytes(sizeof(short))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt16BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt16BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt16LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        stream.ReadBytes(sizeof(short))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt16LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt16LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt32BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        stream.ReadBytes(sizeof(int))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt32BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt32BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt32LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        stream.ReadBytes(sizeof(int))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt32LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt32LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt64BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        stream.ReadBytes(sizeof(long))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt64BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt64BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt64LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        stream.ReadBytes(sizeof(long))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadInt64LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadInt64LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadInt8_Test(IImmutableStream stream)
    {
        var control = (sbyte)stream[0];
        Assert.Equal(control, stream.ReadInt8());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadSingleBigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        stream.ReadBytes(sizeof(float))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadSingleBigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadSingleBigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadSingleLittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        stream.ReadBytes(sizeof(float))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadSingleLittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadSingleLittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadStringBigEndian_Encoding_Test(IImmutableStream stream, Encoding enc, Random rng)
    {
        var length = rng.Next(byte.MaxValue);
        Span<byte> buffer = stackalloc byte[length];
        stream.ReadBytes(length)
            .ToArray()
            .CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        var control = enc.GetString(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadStringBigEndian(length, enc));
    }

    [Theory]
    [ScribeAutoData]
    public void ReadStringBigEndian_Test(IImmutableStream stream, Random rng)
    {
        var length = rng.Next(byte.MaxValue);
        Span<byte> buffer = stackalloc byte[length];
        stream.ReadBytes(length)
            .ToArray()
            .CopyTo(buffer);
        if (BitConverter.IsLittleEndian) buffer.Reverse();
        var control = Encoding.ASCII.GetString(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadStringBigEndian(length));
    }

    [Theory]
    [ScribeAutoData]
    public void ReadStringLittleEndian_Encoding_Test(IImmutableStream stream, Encoding enc, Random rng)
    {
        var length = rng.Next(byte.MaxValue);
        Span<byte> buffer = stackalloc byte[length];
        stream.ReadBytes(length)
            .ToArray()
            .CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        var control = enc.GetString(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadStringLittleEndian(length, enc));
    }

    [Theory]
    [ScribeAutoData]
    public void ReadStringLittleEndian_Test(IImmutableStream stream, Random rng)
    {
        var length = rng.Next(byte.MaxValue);
        Span<byte> buffer = stackalloc byte[length];
        stream.ReadBytes(length)
            .ToArray()
            .CopyTo(buffer);
        if (!BitConverter.IsLittleEndian) buffer.Reverse();
        var control = Encoding.ASCII.GetString(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadStringLittleEndian(length));
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt16BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        stream.ReadBytes(sizeof(ushort))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt16BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt16BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt16LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        stream.ReadBytes(sizeof(ushort))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt16LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt16LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt32BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        stream.ReadBytes(sizeof(uint))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt32BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt32BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt32LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        stream.ReadBytes(sizeof(uint))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt32LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt32LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt64BigEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        stream.ReadBytes(sizeof(ulong))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt64BigEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt64BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void ReadUInt64LittleEndian_Test(IImmutableStream stream)
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        stream.ReadBytes(sizeof(ulong))
            .ToArray()
            .CopyTo(buffer);
        var control = BinaryPrimitives.ReadUInt64LittleEndian(buffer);
        stream.MoveTo(0x00);
        Assert.Equal(control, stream.ReadUInt64LittleEndian());
    }
}
