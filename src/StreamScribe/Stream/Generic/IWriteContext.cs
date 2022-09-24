using System.Text;

namespace StreamScribe.Stream.Generic;

public interface IWriteContext
{
    IWriteContext FillWith(byte value);

    IWriteContext WriteBytes(IEnumerable<byte> context);

    IWriteContext WriteBytes(Span<byte> context);

    IWriteContext WriteDoubleBigEndian(double value);

    IWriteContext WriteDoubleLittleEndian(double value);

    IWriteContext WriteInt16BigEndian(short value);

    IWriteContext WriteInt16LittleEndian(short value);

    IWriteContext WriteInt32BigEndian(int value);

    IWriteContext WriteInt32LittleEndian(int value);

    IWriteContext WriteInt64BigEndian(long value);

    IWriteContext WriteInt64LittleEndian(long value);

    IWriteContext WriteInt8(sbyte value);

    IWriteContext WriteSingleBigEndian(float value);

    IWriteContext WriteSingleLittleEndian(float value);

    IWriteContext WriteStringBigEndian(ReadOnlySpan<char> context);

    IWriteContext WriteStringBigEndian(ReadOnlySpan<char> context, Encoding encoding);

    IWriteContext WriteStringBigEndian(int length, ReadOnlySpan<char> context);

    IWriteContext WriteStringBigEndian(int length, ReadOnlySpan<char> context, Encoding encoding);

    IWriteContext WriteStringLittleEndian(ReadOnlySpan<char> context);

    IWriteContext WriteStringLittleEndian(ReadOnlySpan<char> context, Encoding encoding);

    IWriteContext WriteStringLittleEndian(int length, ReadOnlySpan<char> context);

    IWriteContext WriteStringLittleEndian(int length, ReadOnlySpan<char> context, Encoding encoding);

    IWriteContext WriteUInt16BigEndian(ushort value);

    IWriteContext WriteUInt16LittleEndian(ushort value);

    IWriteContext WriteUInt32BigEndian(uint value);

    IWriteContext WriteUInt32LittleEndian(uint value);

    IWriteContext WriteUInt64BigEndian(ulong value);

    IWriteContext WriteUInt64LittleEndian(ulong value);

    IWriteContext WriteUInt8(byte value);
}
