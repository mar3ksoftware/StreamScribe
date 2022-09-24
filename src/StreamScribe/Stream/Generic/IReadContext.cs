using System.Text;

namespace StreamScribe.Stream.Generic;

public interface IReadContext
{
    void MoveBy(int offset);

    void MoveTo(int position);

    IEnumerable<byte> ReadBytes(int amount);

    double ReadDoubleBigEndian();

    double ReadDoubleLittleEndian();

    short ReadInt16BigEndian();

    short ReadInt16LittleEndian();

    int ReadInt32BigEndian();

    int ReadInt32LittleEndian();

    long ReadInt64BigEndian();

    long ReadInt64LittleEndian();

    sbyte ReadInt8();

    float ReadSingleBigEndian();

    float ReadSingleLittleEndian();

    string ReadStringBigEndian(int lenght);

    string ReadStringBigEndian(int lenght, Encoding encoding);

    string ReadStringLittleEndian(int lenght);

    string ReadStringLittleEndian(int lenght, Encoding encoding);

    ushort ReadUInt16BigEndian();

    ushort ReadUInt16LittleEndian();

    uint ReadUInt32BigEndian();

    uint ReadUInt32LittleEndian();

    ulong ReadUInt64BigEndian();

    ulong ReadUInt64LittleEndian();

    byte ReadUInt8();
}
