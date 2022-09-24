using System.Buffers.Binary;
using System.Text;

namespace StreamScribe.Stream.Generic;

internal abstract class ReadContext : StreamContext, IReadContext
{
    protected ReadContext(IEnumerable<byte> context) : base(context)
    {
    }

    public void MoveBy(int offset)
    {
        Pointer.SetOffset(offset);
    }

    public void MoveTo(int position)
    {
        Pointer.SetPosition(position);
    }

    public IEnumerable<byte> ReadBytes(int amount)
    {
        Span<byte> buffer = stackalloc byte[amount];
        CopyToBuffer(buffer);
        return buffer.ToArray();
    }

    public double ReadDoubleBigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadDoubleBigEndian(buffer);
    }

    public double ReadDoubleLittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(double)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadDoubleLittleEndian(buffer);
    }

    public short ReadInt16BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt16BigEndian(buffer);
    }

    public short ReadInt16LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(short)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt16LittleEndian(buffer);
    }

    public int ReadInt32BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt32BigEndian(buffer);
    }

    public int ReadInt32LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(int)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt32LittleEndian(buffer);
    }

    public long ReadInt64BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt64BigEndian(buffer);
    }

    public long ReadInt64LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(long)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadInt64LittleEndian(buffer);
    }

    public sbyte ReadInt8()
    {
        return (sbyte)GetNextByte();
    }

    public float ReadSingleBigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadSingleBigEndian(buffer);
    }

    public float ReadSingleLittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(float)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadSingleLittleEndian(buffer);
    }

    public string ReadStringBigEndian(int lenght)
    {
        Span<byte> buffer = stackalloc byte[lenght];
        CopyToBuffer(buffer);
        if (BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }
        return Encoding.ASCII.GetString(buffer);
    }

    public string ReadStringBigEndian(int lenght, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[lenght];
        CopyToBuffer(buffer);
        if (BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }
        return encoding.GetString(buffer);
    }

    public string ReadStringLittleEndian(int lenght)
    {
        Span<byte> buffer = stackalloc byte[lenght];
        CopyToBuffer(buffer);
        if (!BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }
        return Encoding.ASCII.GetString(buffer);
    }

    public string ReadStringLittleEndian(int lenght, Encoding encoding)
    {
        Span<byte> buffer = stackalloc byte[lenght];
        CopyToBuffer(buffer);
        if (!BitConverter.IsLittleEndian)
        {
            buffer.Reverse();
        }
        return encoding.GetString(buffer);
    }

    public ushort ReadUInt16BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt16BigEndian(buffer);
    }

    public ushort ReadUInt16LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ushort)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt16LittleEndian(buffer);
    }

    public uint ReadUInt32BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt32BigEndian(buffer);
    }

    public uint ReadUInt32LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(uint)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt32LittleEndian(buffer);
    }

    public ulong ReadUInt64BigEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt64BigEndian(buffer);
    }

    public ulong ReadUInt64LittleEndian()
    {
        Span<byte> buffer = stackalloc byte[sizeof(ulong)];
        CopyToBuffer(buffer);
        return BinaryPrimitives.ReadUInt64LittleEndian(buffer);
    }

    public byte ReadUInt8()
    {
        return GetNextByte();
    }

    private void CopyToBuffer(Span<byte> buffer)
    {
        var length = buffer.Length;
        for (var i = 0; i < length; i++)
        {
            buffer[i] = GetNextByte();
        }
    }

    private byte GetNextByte()
    {
        var value = Context[Pointer.Current];
        Pointer.Advance();
        return value;
    }
}
