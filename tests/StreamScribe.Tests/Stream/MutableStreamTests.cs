using StreamScribe.Stream.Generic;
using StreamScribe.Tests.Attributes;

using System.Text;

namespace StreamScribe.Tests.Stream;

public sealed class MutableStreamTests
{
    [Theory]
    [ScribeAutoData]
    public void Clone_Test(IMutableStream stream)
    {
        var clone = stream.Clone();
        Assert.IsType<MutableStream>(clone);
        Assert.Equal(stream, clone);
    }

    [Theory]
    [ScribeAutoData]
    public void Equals_Test(IMutableStream stream)
    {
        var clone = stream.Clone();
        Assert.IsType<MutableStream>(clone);
        var result = stream.Equals((IMutableStream)clone);
        Assert.True(result);
    }

    [Theory]
    [ScribeAutoData]
    public void FillWith_Test(IMutableStream stream, IEnumerable<byte> randomData, byte value)
    {
        stream.WriteBytes(randomData);
        stream.FillWith(value);
        Assert.Contains(value, stream);
    }

    [Theory]
    [ScribeAutoData]
    public void WriteBytes_Test(IMutableStream stream, IEnumerable<byte> randomData)
    {
        stream.WriteBytes(randomData);
        Assert.Equal(randomData, stream);
    }

    [Theory]
    [ScribeAutoData]
    public void WriteDoubleBigEndian_Test(IMutableStream stream, double value)
    {
        stream.WriteDoubleBigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadDoubleBigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteDoubleLittleEndian_Test(IMutableStream stream, double value)
    {
        stream.WriteDoubleLittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadDoubleLittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt16BigEndian_Test(IMutableStream stream, short value)
    {
        stream.WriteInt16BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt16BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt16LittleEndian_Test(IMutableStream stream, short value)
    {
        stream.WriteInt16LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt16LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt32BigEndian_Test(IMutableStream stream, int value)
    {
        stream.WriteInt32BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt32BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt32LittleEndian_Test(IMutableStream stream, int value)
    {
        stream.WriteInt32LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt32LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt64BigEndian_Test(IMutableStream stream, long value)
    {
        stream.WriteInt64BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt64BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt64LittleEndian_Test(IMutableStream stream, long value)
    {
        stream.WriteInt64LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt64LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteInt8_Test(IMutableStream stream, sbyte value)
    {
        stream.WriteInt8(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadInt8());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteSingleBigEndian_Test(IMutableStream stream, float value)
    {
        stream.WriteSingleBigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadSingleBigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteSingleLittleEndian_Test(IMutableStream stream, float value)
    {
        stream.WriteSingleLittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadSingleLittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringBigEndian_Encoding_Test(IMutableStream stream, string context, Encoding encoding)
    {
        var length = context.Length;
        stream.WriteStringBigEndian(context, encoding);
        stream.MoveTo(0x00);
        Assert.Equal(context, stream.ReadStringBigEndian(length, encoding));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringBigEndian_Length_Encoding_Test(IMutableStream stream, int length, string context, Encoding encoding)
    {
        var streamLength = context.Length + length;
        stream.WriteStringBigEndian(streamLength, context, encoding);
        stream.MoveTo(0x00);
        Assert.Contains(context, stream.ReadStringBigEndian(streamLength, encoding));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringBigEndian_Length_Test(IMutableStream stream, int length, string context)
    {
        var streamLength = context.Length + length;
        stream.WriteStringBigEndian(streamLength, context);
        stream.MoveTo(0x00);
        Assert.Contains(context, stream.ReadStringBigEndian(streamLength));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringBigEndian_Test(IMutableStream stream, string context)
    {
        var length = context.Length;
        stream.WriteStringBigEndian(context);
        stream.MoveTo(0x00);
        Assert.Equal(context, stream.ReadStringBigEndian(length));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringLittleEndian_Encoding_Test(IMutableStream stream, string context, Encoding encoding)
    {
        var length = context.Length;
        stream.WriteStringLittleEndian(context, encoding);
        stream.MoveTo(0x00);
        Assert.Equal(context, stream.ReadStringLittleEndian(length, encoding));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringLittleEndian_Length_Encoding_Test(IMutableStream stream, int length, string context, Encoding encoding)
    {
        var streamLength = context.Length + length;
        stream.WriteStringLittleEndian(streamLength, context, encoding);
        stream.MoveTo(0x00);
        Assert.Contains(context, stream.ReadStringLittleEndian(streamLength, encoding));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringLittleEndian_Length_Test(IMutableStream stream, int length, string context)
    {
        var streamLength = context.Length + length;
        stream.WriteStringLittleEndian(streamLength, context);
        stream.MoveTo(0x00);
        Assert.Contains(context, stream.ReadStringLittleEndian(streamLength));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteStringLittleEndian_Test(IMutableStream stream, string context)
    {
        var length = context.Length;
        stream.WriteStringLittleEndian(context);
        stream.MoveTo(0x00);
        Assert.Equal(context, stream.ReadStringLittleEndian(length));
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt16BigEndian_Test(IMutableStream stream, ushort value)
    {
        stream.WriteUInt16BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt16BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt16LittleEndian_Test(IMutableStream stream, ushort value)
    {
        stream.WriteUInt16LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt16LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt32BigEndian_Test(IMutableStream stream, uint value)
    {
        stream.WriteUInt32BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt32BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt32LittleEndian_Test(IMutableStream stream, uint value)
    {
        stream.WriteUInt32LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt32LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt64BigEndian_Test(IMutableStream stream, ulong value)
    {
        stream.WriteUInt64BigEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt64BigEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt64LittleEndian_Test(IMutableStream stream, ulong value)
    {
        stream.WriteUInt64LittleEndian(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt64LittleEndian());
    }

    [Theory]
    [ScribeAutoData]
    public void WriteUInt8_Test(IMutableStream stream, byte value)
    {
        stream.WriteUInt8(value);
        stream.MoveTo(0x00);
        Assert.Equal(value, stream.ReadUInt8());
    }
}
